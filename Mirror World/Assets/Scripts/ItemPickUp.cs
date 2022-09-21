using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ConsumableA,
    ConsumableB
}

public class ItemPickUp : MonoBehaviour
{
    public ItemType itemType;

    ConsumableItem item;
    // Start is called before the first frame update
    void Start()
    {
        switch (itemType)
        {
            case ItemType.ConsumableA:
                item = new ConsumableA();
                break;
            case ItemType.ConsumableB:
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
