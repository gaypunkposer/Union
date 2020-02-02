using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Touchable
{
    public TaskType type;
    public bool inUse;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        inUse = false;
    }
    public void setType(TaskType type) {
        this.type = type;
    }
}