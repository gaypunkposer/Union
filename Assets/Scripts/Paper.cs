using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Paper : Touchable
{
    public TaskType type;
    public bool inUse;
    private bool touched = false;

    public Sprite faxSprite, shredSprite;

    void Start()
    {
        onTouchStart.AddListener(OnTouch);
        onTouchEnd.AddListener(OnRelease);
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
<<<<<<< HEAD
    public void setType(TaskType type) {
        this.type = type;
    }

=======

    void setType(TaskType type)
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

    private void OnCollisionEnter(Collision collision)
    {
        inUse = false;
    }
>>>>>>> origin/master
}