using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class OnTouchCompleteLine : MonoBehaviour
{
    public DialogueUI dialogueUI;
    private bool _canUpdate;

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) ||
            Input.GetMouseButtonDown(0))
        {
            dialogueUI.MarkLineComplete();
        }
            
    }

    public void CanUpdate()
    {
        _canUpdate = true;
    }
    
}
