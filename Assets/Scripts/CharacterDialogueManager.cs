using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class CharacterDialogueManager : MonoBehaviour
{
    public DialogueRunner runner;

    public void StartDialogue()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Touchable>().enabled = false;
        }
    }

    public void EndDialogue()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.GetComponent<Touchable>().enabled = true;
        }
    }
}
