using System.Collections.Generic;
using UnityEngine;

// this make it possibe to create new EventData objects from menu
[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObjects/Dialogue Data", order = 1)]
public class DialogueScriptableObject : ScriptableObject
{
    public int dialogueId;                      // used to find the right dialogue
    [TextArea] public string description;       // just for editor
    [Space(20)]
    public List<DialogueObject> dialogueObjects;   // lits of all the texts in the dialogue
}
