using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ConsumableItem : ItemBase
{
    public int amount;

    public ConsumableItem(int _id, string _name, Sprite _sprite, string _description)
    {
        id = _id;
        name = _name;
        sprite = _sprite;
        description = _description;
        amount = 1;
    }

    public void UseItem(List<ConsumableItem> list)
    {
        Debug.Log("Item used");
        // TO DO, STUFF THAT HAPPENS WHEN ITEM IS USED
        amount--;

        if (amount < 1)
        {
            Debug.Log("All items used");
            list.Remove(this);
            EventManager.AllItemsUsed(this);
        }
    }
}
