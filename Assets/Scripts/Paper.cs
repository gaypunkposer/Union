using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paper : Draggable
{
    private TaskType type;
    public bool inUse;
    private bool touched = false;

    public Sprite faxSprite, shredSprite;

    void Start()
    {
        onTouchStart.AddListener(OnTouch);
        onTouchEnd.AddListener(OnRelease);
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTouch()
    {
        touched = true;
    }

    private void OnRelease()
    {
        touched = false;
    }

    public bool isTouched()
    {
        return touched;
    }
    public void setType(TaskType type)
    {
        this.type = type;
        if (type == TaskType.PaperFax)
        {
            GetComponent<SpriteRenderer>().sprite = faxSprite;
        }

        if (type == TaskType.PaperShred)
        {
            GetComponent<SpriteRenderer>().sprite = shredSprite;
        }
    }

    public TaskType getType()
    {
        return type;
    }

    private void OnCollisionEnter(Collision collision)
    {
        inUse = false;
    }
}