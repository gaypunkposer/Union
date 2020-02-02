using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredBehavior : MonoBehaviour
{
    public Pool pool;
    public MinigameController mg;
    public AudioSource soundFX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //check the TaskType Paper
        Paper p = other.GetComponent<Paper>();

        if (p == null) { 
            Debug.Log("Error this is not a paper");
            return;
        }
        else if (p.getType() == TaskType.PaperShred)
        {
            mg.completed++;
        }
            pool.ReleasePaper(p);
            soundFX.Play();
    }
}
