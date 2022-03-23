using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int health;
    public List<PermanentItem> permanentItems = new List<PermanentItem>();
    public List<ConsumableItem> consumableItems = new List<ConsumableItem>();
    PermanentItem equippedItem;

    public void EquipItem(PermanentItem item)
    {
        equippedItem = item;
    }

    public void AddPermanentItem(PermanentItem item)
    {
        permanentItems.Add(item);
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
