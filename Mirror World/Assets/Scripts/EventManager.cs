using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static event Action<ConsumableItem> OnAllItemsUsed;

    public static void AllItemsUsed(ConsumableItem item)
    {
        OnAllItemsUsed?.Invoke(item);
    }
}
