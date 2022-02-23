using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text textField;          // text box for dialogue
    public Button[] choiceButtons;  // buttons for multiple choice parts

    private Object[] dialogueArray;                     // array of all dialogues in the game
    private DialogueScriptableObject currentDialogue;   // variable that holds the dialogue currently being played
    private int dialogueObjectIndex;                    // indexer for going through the diaogue

    void Start()
    {
        dialogueArray = Resources.LoadAll("DialogueData");
        ButtonListenerSetup();
        // this was for testing
        //StartDialogue(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currentDialogue != null && currentDialogue.dialogueObjects[dialogueObjectIndex].type != ObjectType.choice)
                NextDialogueObject();
        }
    }

    public void StartDialogue(int dialogueId)
    {
        textField.gameObject.SetActive(true);

        dialogueObjectIndex = 0;
        currentDialogue = FindDialogue(dialogueId);
    }

    private void StopDialogue()
    {
        textField.gameObject.SetActive(false);
    }

    // find the right dialogue from among all the dialogues
    private DialogueScriptableObject FindDialogue(int dialogueId)
    {
        // go through all dialoues
        foreach (DialogueScriptableObject obj in dialogueArray)
        {
            // if dialogue ID matches
            if (obj.dialogueId == dialogueId)
            {
                // set the first text
                textField.text = obj.dialogueObjects[dialogueObjectIndex].text;
                // return the right dialogue data for future processing
                return obj;
            }
        }

        // dialogue was not found
        Debug.LogError("Dialogue not found!");
        return null;
    }

    private void NextDialogueObject()
    {
        // dialogue end
        if (currentDialogue.dialogueObjects[dialogueObjectIndex].nextObjectIndex == 0)
        {
            StopDialogue();
        }
        // dialogue continue
        else
        {
            // update the index of dialogueObject
            dialogueObjectIndex = currentDialogue.dialogueObjects[dialogueObjectIndex].nextObjectIndex;

            // if the new dialogueObject is text, update the textField
            if (currentDialogue.dialogueObjects[dialogueObjectIndex].type == ObjectType.text)
            {
                textField.text = currentDialogue.dialogueObjects[dialogueObjectIndex].text;
            }

            // if the new dialogueObject is choice object, show choice buttons
            else if (currentDialogue.dialogueObjects[dialogueObjectIndex].type == ObjectType.choice)
            {
                ShowChoiceButtons();
                textField.text = currentDialogue.dialogueObjects[dialogueObjectIndex].text;
            }
        }
    }

    private void ButtonListenerSetup()
    {
        // set listeners to all choice buttons - this is done this way for a reason that includes how memory and stack works, ask your coder for details if interested
        int count = 0;
        foreach (Button btn in choiceButtons)
        {
            var current = count;
            choiceButtons[current].onClick.AddListener(() => ButtonClick(current));
            count++;

            btn.gameObject.SetActive(false);
        }
    }

    // Function for buttons
    private void ButtonClick(int index)
    {
        List<ChoiceObject> buttonChoiceObjects = currentDialogue.dialogueObjects[dialogueObjectIndex].choices;

        dialogueObjectIndex = buttonChoiceObjects[index].nextObjectIndex;
        textField.text = currentDialogue.dialogueObjects[dialogueObjectIndex].text;

        foreach (Button btn in choiceButtons)
        {
            btn.gameObject.SetActive(false);
        }

        // next object is choice so show buttons
        if (currentDialogue.dialogueObjects[dialogueObjectIndex].type == ObjectType.choice)
            ShowChoiceButtons();
    }

    private void ShowChoiceButtons()
    {
        List<ChoiceObject> choices = new List<ChoiceObject>();
        choices = currentDialogue.dialogueObjects[dialogueObjectIndex].choices;

        int i = 0;
        // go through all valid choices
        foreach (ChoiceObject obj in choices)
        {
            // calculates the Y-position of button
            float tmp = (choices.Count / 2 * 100) + 100 - 100 * i;
            // set button position
            choiceButtons[i].GetComponent<RectTransform>().localPosition = new Vector2(0, tmp);
            // set button content
            choiceButtons[i].GetComponentInChildren<Text>().text = choices[i].choiceText;
            // set to interactable, in case it was previously set to false
            choiceButtons[i].GetComponent<Button>().interactable = true;
            // set button active
            choiceButtons[i].gameObject.SetActive(true);
            i++;
        }
    }
}
