using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Item Data", menuName = "ScriptableObjects/Consumable Item", order = 2)]
public class ConsumableItemSO : ScriptableObject
{
    public int id;
    public new string name;
    public Sprite sprite;
    public string description;

    //public int amount;
    //public List<ConsumableItemSO> homeList;

    //public ConsumableItemSO(int _id, string _name, Sprite _sprite, string _description, int _amount) : base(_id, _name, _sprite, _description)
    //{
    //    amount = _amount;
    //}

    //public void UseItem()
    //{
    //    Debug.Log("Item used");
    //    // TO DO, STUFF THAT HAPPENS WHEN ITEM IS USED
    //    amount--;

    //    if (amount < 1)
    //    {
    //        Debug.Log("All items used");
    //        homeList.Remove(this);
    //    }
    //}
}
