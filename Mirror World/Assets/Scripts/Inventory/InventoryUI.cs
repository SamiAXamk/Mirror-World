using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public event Action<ConsumableItem, KeyCode?> OnSetHotbarItem;

    [SerializeField] GameObject inventoryParentGameObject;
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject inventoryObjectHolder;
    [SerializeField] GameObject infoTextGameObject;
    [SerializeField] GameObject personTab;
    [SerializeField] GameObject itemTab;
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] int padding;
    [SerializeField] Color hoverColor;

    Player playerScript;
    GameObject inventoryConsumablesParent;
    GameObject inventoryPermanentsParent;
    Text infoText;

    int selectedItemIndex = 0;
    Color transparentColor = new Color(0, 0, 0, 0);

    List<GameObject> inventoryConsumableHolders = new List<GameObject>();
    List<GameObject> inventoryPermanentHolders = new List<GameObject>();
    List<KeyCode> hotbarKeycodes = new List<KeyCode>();

    // Start is called before the first frame update
    void Start()
    {
        hotbarKeycodes.Add(KeyCode.Alpha1);
        hotbarKeycodes.Add(KeyCode.Alpha2);
        hotbarKeycodes.Add(KeyCode.Alpha3);
        hotbarKeycodes.Add(KeyCode.Alpha4);
        hotbarKeycodes.Add(KeyCode.Alpha5);

        playerScript = playerObject.GetComponent<Player>();
        inventoryConsumablesParent = inventoryParentGameObject.transform.GetChild(0).gameObject;
        inventoryPermanentsParent = inventoryParentGameObject.transform.GetChild(1).gameObject;
        infoText = infoTextGameObject.GetComponent<Text>();

        SetupInventoryObjectHolders();

        EventManager.OnAllItemsUsed += SetItemsInInventory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            InventoryToggle();

        if (Input.GetKeyDown(KeyCode.Tab))
            TabToggle();

        // handles the movement in the inventory view
        if (inventoryParentGameObject.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
                HoveredItem(1);
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                HoveredItem(-1);
            if (Input.GetKeyDown(KeyCode.DownArrow))
                HoveredItem(columns);
            if (Input.GetKeyDown(KeyCode.UpArrow))
                HoveredItem(-columns);

            // set the description for the item
            infoText.text = inventoryConsumableHolders[selectedItemIndex].GetComponent<InventoryObjectContainer>().itemData.description;

            // if hotbar button was pressed, set the item in the hotbar
            if(GetPressedKeycode() != null)
            {
                SetHotbarButton(ref inventoryConsumableHolders[selectedItemIndex].GetComponent<InventoryObjectContainer>().itemData, GetPressedKeycode());
            }
        }
    }

    private void InventoryToggle()
    {
        if (inventoryParentGameObject.activeSelf)
            inventoryParentGameObject.SetActive(false);
        else
        {
            inventoryParentGameObject.SetActive(true);
            inventoryConsumableHolders[selectedItemIndex].GetComponent<Image>().color = hoverColor;
        }
    }

    private void TabToggle()
    {
        if (inventoryConsumablesParent.activeSelf)
        {
            inventoryConsumablesParent.SetActive(false);
            itemTab.GetComponent<Image>().color = transparentColor;
            inventoryPermanentsParent.SetActive(true);
            personTab.GetComponent<Image>().color = hoverColor;
        }
        else
        {
            inventoryConsumablesParent.SetActive(true);
            itemTab.GetComponent<Image>().color = hoverColor;
            inventoryPermanentsParent.SetActive(false);
            personTab.GetComponent<Image>().color = transparentColor;
        }
    }

    // sets the positions of the inventoryObjectHolders
    private void SetupInventoryObjectHolders()
    {
        // get the width of the panel
        var width = (inventoryConsumablesParent.GetComponent<RectTransform>().rect.width - padding * (columns + 1)) / columns;

        // Set positions and sizes of inventoryObjectHolders
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var xPos = padding * (j + 1) + width * j;
                var yPos = -padding * (i + 1) - width * i;
                var obj = Instantiate(inventoryObjectHolder, inventoryConsumablesParent.transform);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos, 0);
                obj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width);
                obj.GetComponent<BoxCollider2D>().size = new Vector2(width, width);
                obj.GetComponent<BoxCollider2D>().offset = new Vector2(width / 2, -width / 2);

                var obj2 = Instantiate(obj, inventoryPermanentsParent.transform);

                inventoryConsumableHolders.Add(obj);
                inventoryPermanentHolders.Add(obj2);
            }
        }

        SetItemsInInventory();
    }

    // sets the actual items in the inventoryObjectHolders
    private void SetItemsInInventory()
    {
        // Set items and sprites on inventoryObjectHolders
        int k = 0;
        foreach (ConsumableItem item in playerScript.consumableItems)
        {
            inventoryConsumableHolders[k].GetComponent<InventoryObjectContainer>().itemData = item;
            inventoryConsumableHolders[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
            k++;
        }
    }

    private void SetItemsInInventory(ConsumableItem obj)
    {
        // Set items and sprites on inventoryObjects
        int k = 0;
        foreach (ConsumableItem item in playerScript.consumableItems)
        {
            inventoryConsumableHolders[k].GetComponent<InventoryObjectContainer>().itemData = item;
            inventoryConsumableHolders[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
            k++;
        }
        inventoryConsumableHolders[k].GetComponent<InventoryObjectContainer>().itemData = null;
        inventoryConsumableHolders[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
    }

    private void SetHotbarButton(ref ConsumableItem item, KeyCode? keyCode)
    {
        OnSetHotbarItem?.Invoke(item, keyCode);
    }

    // highlights the hovered item
    private void HoveredItem(int change)
    {
        inventoryConsumableHolders[selectedItemIndex].GetComponent<Image>().color = transparentColor;

        if (selectedItemIndex + change >= 0 && selectedItemIndex + change < inventoryConsumableHolders.Count)
            selectedItemIndex += change;

        inventoryConsumableHolders[selectedItemIndex].GetComponent<Image>().color = hoverColor;
    }

    // returns the hotbarkey being pressed or null
    private KeyCode? GetPressedKeycode()
    {
        foreach(KeyCode key in hotbarKeycodes)
        {
            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }

        return null;
    }
}