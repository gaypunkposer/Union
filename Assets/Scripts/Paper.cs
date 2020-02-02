using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Touchable
{
    public TaskType type;
    public bool inUse;

    public Sprite faxSprite, shredSprite;
    // Update is called once per frame
    void Update()
    {
        
    }

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
}