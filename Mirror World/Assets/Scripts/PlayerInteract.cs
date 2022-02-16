using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Collider2D interactableElement = null;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactable"))
        {
            //other.gameObject.GetComponent<Interactable>().Interacted();
            interactableElement = other;
            interactableElement.gameObject.GetComponent<Interactable>().ShowTutorialE(10);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactable"))
        {
            interactableElement.gameObject.GetComponent<Interactable>().ShowTutorialE(-10);
            interactableElement = null;
        }
    }

    public void PressedE()
    {
        if (interactableElement != null)
        {
            interactableElement.gameObject.GetComponent<Interactable>().Interacted();
        }
    }

}
