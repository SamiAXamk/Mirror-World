using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public GameObject ECanvas;

    //This method should start dialog or reference something that does. This could also be used to pick up items, if we so wish.
    public void Interacted()
    {
        Debug.Log("OMG! I'm being interacted!");
    }

    public void ShowTutorialE(int layer)
    {
        ECanvas.transform.position = transform.position;
        ECanvas.GetComponent<Canvas>().sortingOrder = layer;
    }

}
