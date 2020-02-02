using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredBehavior : MonoBehaviour
{
    public Pool pool;
    public MinigameController mg;
    public AudioSource soundFX;
    
    private Animator _animator;

    private static readonly int Shred = Animator.StringToHash("Shred");

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
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

        _animator.SetTrigger(Shred);
        TouchInput.Instance.ForceTouchToEnd();
        pool.ReleasePaper(p);
        soundFX.Play();
    }
}
