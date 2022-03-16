/*  Original code by Jason Weimann
 *  https://www.youtube.com/watch?v=kdckcSwPkrg
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotbar : MonoBehaviour
{
    public GameObject inventoryParent;

    [SerializeField] GameObject gameManager;

    private void Awake()
    {
        // Go through all child objects(buttons) and assign function to them that is called when the button is clicked
        foreach (var button in GetComponentsInChildren<HotbarButton>())
        {
            //button.OnButtonClick += ButtonClickFunction;
            gameManager.GetComponent<InventoryUI>().OnSetHotbarItem += button.SetHotbarItemFunction;

            EventManager.OnAllItemsUsed += button.ClearHotbarButton;
        }
    }

    private void ButtonClickFunction(int buttonNumber)
    {
        Debug.Log($"Button {buttonNumber} clicked!");
    }
}
