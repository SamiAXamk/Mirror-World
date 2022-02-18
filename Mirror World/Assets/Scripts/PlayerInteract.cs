using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    List<Collider2D> Interactables = new List<Collider2D>();
    


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactable"))
        {
            Interactables.Add(other);
            other.gameObject.GetComponent<Interactable>().ShowTutorialE(10);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (Interactables.Contains(other))
        {
            other.gameObject.GetComponent<Interactable>().ShowTutorialE(-10);
            Interactables.Remove(other);
        }
    }

    public void PressedE()
    {
        if (Interactables.Count != 0)
        {
            Interactables[0].gameObject.GetComponent<Interactable>().Interacted();
        }
    }

}
