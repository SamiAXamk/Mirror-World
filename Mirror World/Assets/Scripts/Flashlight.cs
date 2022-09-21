using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[serializable]
public class Flashlight : PermanentItem
{
    GameObject flashlightGO;

    public Flashlight(int _id, string _name, Sprite _sprite, string _description) : base(_id, _name, _sprite, _description)
    {
        flashlightGO = GameObject.FindWithTag("Flashlight");
        Debug.Log(flashlightGO);
    }

    public void UseItem(List<PermanentItem> list)
    {
        Debug.Log("Used flashlight!");
        flashlightGO.SetActive(!flashlightGO.activeSelf);
    }
}
