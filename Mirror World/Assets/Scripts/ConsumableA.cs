using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableA : ConsumableItem
{
    public ConsumableA(int _id, string _name, Sprite _sprite, string _description) : base(_id, _name, _sprite, _description)
    {
        
    }

    public override void UseItem(List<ConsumableItem> list)
    {
        Debug.Log("vekotin");
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
