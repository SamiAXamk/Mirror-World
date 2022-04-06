using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is for storing the item data in inventoryObjects, because consumableitems are not monobehaviours
public class InventoryObjectContainer : MonoBehaviour
{
    public ConsumableItem consumableItemData;
    public PermanentItem permanentItemData;
}
