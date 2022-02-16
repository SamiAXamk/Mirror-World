using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject playerObject;
    [SerializeField] GameObject inventoryObject;
    [SerializeField] int objectsInRow;
    Player player;
    GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObject.GetComponent<Player>();
        inventory = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.activeSelf)
                inventory.SetActive(false);
            else
                OpenInventory();
        }
    }

    void OpenInventory()
    {
        int i = 0;

        foreach(ConsumableItem item in player.consumableItems)
        {
            var obj = Instantiate(inventoryObject, inventory.transform);
            var xPos = 30 * (i+1) + obj.GetComponent<RectTransform>().rect.width * i;
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(xPos, -30, 0);
            i++;
        }

        inventory.SetActive(true);
    }
}

// TO DO
// make all inventory slots in start
// show correct amount of slots in openinventory
// item references in slots