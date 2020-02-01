using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    private List<Paper> paperPool;

    private int inUse;
    // Start is called before the first frame update
    void Start()
    {
        paperPool = new List<Paper>();
        inUse = 0;
        for (int i = 0; i < 30; i++)
        {
            Paper p = gameObject.AddComponent<Paper>();
            p.gameObject.AddComponent<Rigidbody2D>();
            p.gameObject.AddComponent<Collider2D>();
            p.inUse = false;
            paperPool.Add(p);
        }
    }

    void PlacePaper(TaskType type)
    {
        Paper p = null;
        if (inUse == paperPool.Count)
        {
            p = gameObject.AddComponent<Paper>();
            p.gameObject.AddComponent<Rigidbody2D>();
            p.gameObject.AddComponent<Collider2D>();
            paperPool.Add(p);
        }
        else
        {
            for (int i = 0; i < paperPool.Count; i++)
            {
                if (!paperPool[i].inUse)
                    p = paperPool[i];
            }
        }
        p.inUse = true;
        p.type = type;
        //do stuff like place the paper
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
