using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class ItemBase : ScriptableObject
{
    [SerializeField] int id;
    [SerializeField] string name;
    [SerializeField] Sprite sprite;
    [SerializeField] string description;
}
