using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string description;

    //public GameObject interactionIndicator;
    //GameObject descriptionBox;

    private void Start()
    {
        //interactionIndicator = GameObject.FindGameObjectWithTag("E");
    }

    //This method should start dialog or reference something that does. This could also be used to pick up items, if we so wish.
    public string Interacted()
    {
        //Debug.Log("OMG! I'm being interacted!");
        return description;
    }

    // Shows interaction indicator
    //public void ShowTutorialE(bool active)
    //{
    //    interactionIndicator.transform.position = transform.position;
    //    //interactionIndicator.GetComponent<Canvas>().sortingOrder = layer;
    //    interactionIndicator.SetActive(active);
    //}

}
