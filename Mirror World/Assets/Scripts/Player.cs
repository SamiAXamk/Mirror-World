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
        consumableItems.Add(item);
    }
}
