using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public Canvas canva;
    public GameObject descriptionBox;

    List<Collider2D> interactables = new List<Collider2D>();
    List<Collider2D> dialogues = new List<Collider2D>();
    //private int listLast = 0;

    GameObject interactionIndicator;

    private void Start()
    {
        interactionIndicator = GameObject.FindGameObjectWithTag("E");
        interactionIndicator.SetActive(false);
    }

    //Calls for the last item on the list to be used.
    public void PressedE()
    {
        if(dialogues.Count != 0)
        {
            //listLast = dialogues.Count - 1;

            dialogueManager.StartDialogue(dialogues[dialogues.Count - 1].gameObject.GetComponent<DialogueContainer>().dialogue);
        }
        else if (interactables.Count != 0 && !descriptionBox.activeSelf)
        {
            descriptionBox.SetActive(true);
            //listLast = interactables.Count - 1;

            descriptionBox.GetComponentInChildren<TextMeshProUGUI>().text = interactables[interactables.Count - 1].gameObject.GetComponent<Interactable>().Interacted();
        }
        else
            descriptionBox.SetActive(false);
    }

    //Adds interactable to the list
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            interactables.Add(other);

            //other.gameObject.GetComponent<Interactable>().ShowTutorialE(true);
            ShowInteractIndicator(true, other.gameObject.transform.position);
        }
        else if (other.gameObject.CompareTag("Dialogue"))
        {
            dialogues.Add(other);

            ShowInteractIndicator(true, other.gameObject.transform.position);
        }
    }

    //Removes interactable from the list.
    private void OnTriggerExit2D(Collider2D other)
    {

        if (interactables.Contains(other))
        {
            interactables.Remove(other);

            if (interactables.Count == 0)
            {
                //other.gameObject.GetComponent<Interactable>().ShowTutorialE(false);
                ShowInteractIndicator(false, null);
            }
        }
        else if (dialogues.Contains(other))
        {
            dialogues.Remove(other);

            if(dialogues.Count == 0)
            {
                ShowInteractIndicator(false, null);
            }
        }
    }

    private void ShowInteractIndicator(bool active, Vector3? target)
    {
        //interactionIndicator.transform.position = transform.position;
        interactionIndicator.SetActive(active);

        if (target != null)
        {
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, (Vector3)target);
            //healthBar.anchoredPosition = screenPoint - canvasRectT.sizeDelta / 2f;
            interactionIndicator.GetComponent<RectTransform>().anchoredPosition = screenPoint - canva.GetComponent<RectTransform>().sizeDelta / 2f;
        }
    }
}
