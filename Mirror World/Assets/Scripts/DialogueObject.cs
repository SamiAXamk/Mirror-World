using System.Collections.Generic;
using UnityEngine;

/*Each invidual view/text in a dialogue is an DialogueObject. 
 */

[System.Serializable]
public class DialogueObject
{
    public int nextObjectIndex;         // reference to the next DialogueObject
    public int previousObjectIndex;     // in case there ever is need to go back to previous DialogueObject
    public ObjectType type;             // tells if the current DialogueObject is text or choice object
    [TextArea(5,10)]
    public string text;      // contains the text for text DialogueObject

    public List<ChoiceObject> choices;  // list of all the choices

    // TO DO
    // quest activation in dialogue
}