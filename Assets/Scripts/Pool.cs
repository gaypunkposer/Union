using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    private List<Paper> paperPool;

    private int inUse;
    public GameObject paperPrefab;

    public MinigameController mc;
    // Start is called before the first frame update
    void Start()
    {
        paperPool = new List<Paper>();
        inUse = 0;
        for (int i = 0; i < 30; i++)
        {
            GameObject go = Instantiate(paperPrefab, Vector3.zero, Quaternion.identity);
            go.SetActive(false);
            Paper p = go.GetComponent<Paper>();
            p.inUse = false;
            paperPool.Add(p);
        }
        mc.spawnTimer.AddListener(PlacePaper);
    }

    void PlacePaper(TaskType type)
    {
        if (type != TaskType.PaperFax && type != TaskType.PaperShred)
            return;
        Paper p = null;
        if (inUse == paperPool.Count)
        {
            GameObject go = Instantiate(paperPrefab, Vector3.zero, Quaternion.identity);
            p = go.GetComponent<Paper>();
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
        p.gameObject.transform.position = Vector3.zero;
        p.gameObject.SetActive(true);
        p.inUse = true;
        p.type = type;
        //do stuff like place the paper
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
