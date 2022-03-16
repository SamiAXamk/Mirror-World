using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class ItemBase
{
    public int id;
    public string name;
    public Sprite sprite;
    public string description;

    //public ItemBase(int _id, string _name, Sprite _sprite, string _description)
    //{
    //    id = _id;
    //    name = _name;
    //    sprite = _sprite;
    //    description = _description;
    //}
}
