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
    [SerializeField] GameObject inventoryObject;
    [SerializeField] GameObject infoTextGameObject;
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] int padding;
    [SerializeField] Color hoverColor;

    Player playerScript;
    GameObject inventory;
    Text infoText;
    int selectedItemIndex = 0;
    Color transparentColor = new Color(0, 0, 0, 0);

    List<GameObject> inventoryObjects = new List<GameObject>();
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
        inventory = inventoryParentGameObject.transform.GetChild(0).gameObject;
        infoText = infoTextGameObject.GetComponent<Text>();

        SetupInventoryObjects();

        EventManager.OnAllItemsUsed += SetItemsInInventory;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
            InventoryToggle();

        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    var item = playerScript.consumableItems[0];
        //    SetHotbarButton(ref item, KeyCode.Alpha1);
        //}

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

            infoText.text = inventoryObjects[selectedItemIndex].GetComponent<InventoryObjectContainer>().itemData.description;

            if(GetPressedKeycode() != null)
            {
                SetHotbarButton(ref inventoryObjects[selectedItemIndex].GetComponent<InventoryObjectContainer>().itemData, GetPressedKeycode());
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
            inventoryObjects[selectedItemIndex].GetComponent<Image>().color = hoverColor;
        }
    }

    private void SetupInventoryObjects()
    {
        var width = (inventory.GetComponent<RectTransform>().rect.width - padding * (columns + 1)) / columns;

        // Set positions and sizes of inventoryObjects
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var xPos = padding * (j + 1) + width * j;
                var yPos = -padding * (i + 1) - width * i;
                var obj = Instantiate(inventoryObject, inventory.transform);
                obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, yPos, 0);
                obj.GetComponent<RectTransform>().sizeDelta = new Vector2(width, width);
                obj.GetComponent<BoxCollider2D>().size = new Vector2(width, width);
                obj.GetComponent<BoxCollider2D>().offset = new Vector2(width / 2, -width / 2);
                inventoryObjects.Add(obj);
            }
        }

        SetItemsInInventory();
    }

    private void SetItemsInInventory()
    {
        // Set items and sprites on inventoryObjects
        int k = 0;
        foreach (ConsumableItem item in playerScript.consumableItems)
        {
            inventoryObjects[k].GetComponent<InventoryObjectContainer>().itemData = item;
            inventoryObjects[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
            k++;
        }
    }

    private void SetItemsInInventory(ConsumableItem obj)
    {
        // Set items and sprites on inventoryObjects
        int k = 0;
        foreach (ConsumableItem item in playerScript.consumableItems)
        {
            inventoryObjects[k].GetComponent<InventoryObjectContainer>().itemData = item;
            inventoryObjects[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = item.sprite;
            k++;
        }
        inventoryObjects[k].GetComponent<InventoryObjectContainer>().itemData = null;
        inventoryObjects[k].transform.GetChild(0).gameObject.GetComponent<Image>().sprite = null;
    }

    private void SetHotbarButton(ref ConsumableItem item, KeyCode? keyCode)
    {
        OnSetHotbarItem?.Invoke(item, keyCode);
    }

    private void HoveredItem(int change)
    {
        inventoryObjects[selectedItemIndex].GetComponent<Image>().color = transparentColor;

        if (selectedItemIndex + change >= 0 && selectedItemIndex + change < inventoryObjects.Count)
            selectedItemIndex += change;

        inventoryObjects[selectedItemIndex].GetComponent<Image>().color = hoverColor;
    }

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