using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : Touchable
{
    public float dragSpeed = 35;
    protected override void InitializeObject()
    {
        base.InitializeObject();
        onDragged.AddListener(MoveOnDrag);
    }

    private void MoveOnDrag()
    {
        Vector2 delta = TouchInput.Instance.TouchPosition - body.position;
        body.AddForce(delta * (dragSpeed), ForceMode2D.Force);
    }
}
