/*  Original code by Jason Weimann
 *  https://www.youtube.com/watch?v=kdckcSwPkrg
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarButton : MonoBehaviour
{
    public event Action<int> OnButtonClick;

    private KeyCode keyCode;
    private TMP_Text text;
    private int keyNumber;

    private ConsumableItem itemRef;
    private Player player;
    private GameObject inventoryParent;

    // This is called in editor when the scene is saved, among other things.
    // Sets the name of the gameobject and the text on the button
    private void OnValidate()
    {
        keyNumber = transform.GetSiblingIndex() + 1;
        keyCode = KeyCode.Alpha0 + keyNumber;

        if (text == null)
            text = GetComponentInChildren<TMP_Text>();

        text.SetText(keyNumber.ToString());
        gameObject.name = "HotbarButton" + keyNumber;
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(HandleClick);
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        inventoryParent = gameObject.GetComponentInParent<Hotbar>().inventoryParent;
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
        {
            HandleClick();
        }
    }

    private void HandleClick()
    {
        // The ? checks that OnButtonClick is assigned and then invokes.
        // This way there won't be null reference exception if it isn't assigned.
        // Invokes the OnButtonClick function assigned to this button.

        //OnButtonClick?.Invoke(keyNumber);

        if (!inventoryParent.activeSelf)
            itemRef?.UseItem(player.consumableItems);
    }

    public void SetHotbarItemFunction(ConsumableItem item, KeyCode? _keyCode)
    {
        if (_keyCode == keyCode)
        {
            Debug.Log("SetHotbarItemFunction");
            itemRef = item;
            GetComponent<Image>().sprite = item.sprite;
        }
    }

    public void ClearHotbarButton(ConsumableItem item)
    {
        if (item?.id == itemRef?.id)
        {
            itemRef = null;
            GetComponent<Image>().sprite = null;
        }

    }
}
