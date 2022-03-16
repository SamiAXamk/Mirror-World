using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health;
    public List<WearableItem> wearableItems = new List<WearableItem>();
    public List<ConsumableItem> consumableItems = new List<ConsumableItem>();
    WearableItem equippedItem;

    public void EquipItem(WearableItem item)
    {
        equippedItem = item;
    }

    public void AddWearableItem(WearableItem item)
    {
        wearableItems.Add(item);
    }

    public void AddConsumableItem(ConsumableItem item)
    {
        foreach(ConsumableItem obj in consumableItems)
        {
            if(obj.id == item.id)
            {
                item.amount++;
                // player already had the item so increment it's amount and return from the function
                return;
            }
        }
        // player did't have the item so add it to the list
        consumableItems.Add(item);
    }
}
