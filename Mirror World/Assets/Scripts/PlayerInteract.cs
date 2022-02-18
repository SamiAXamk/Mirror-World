using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    List<Collider2D> Interactables = new List<Collider2D>();
    private int listLast = 0;

    //Adds interactable to the list
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Interactable"))
        {
            Interactables.Add(other);
            
            other.gameObject.GetComponent<Interactable>().ShowTutorialE(10);
        }
    }

    //Removes interactable from the list.
    private void OnTriggerExit2D(Collider2D other)
    {

        if (Interactables.Contains(other))
        {
            
            Interactables.Remove(other);
            
            if (Interactables.Count == 0)
            {
                other.gameObject.GetComponent<Interactable>().ShowTutorialE(-10);
            }
        }
    }

    //Calls for the last item on the list to be used.
    public void PressedE()
    {
        if (Interactables.Count != 0)
        {
            listLast = Interactables.Count - 1;

            Interactables[listLast].gameObject.GetComponent<Interactable>().Interacted();
        }
    }

}
