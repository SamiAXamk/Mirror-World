using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/Consumable Item", order = 2)]
public class ConsumableItem : ItemBase
{
    public void UseItem(ref List<ConsumableItem> list)
    {
        // TO DO STUFF THAT HAPPENS WHEN ITEM IS USED
        list.Remove(this);
    }
}
