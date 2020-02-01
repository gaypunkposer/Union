using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour
{
    public float startTime;
    public float gameAccelerator;
    public float startAccelerator = 1;
    public float maxAccelerator;
    public float GAME_SECONDS = 30;

    public float[] MAX_ACCEL_PER_LEVEL = new float[3] {1, 4, 2 };

    public int level = 0;
    public bool active = false;

    public Camera horizontalCamera, verticalCamera;
    public Scene gameScene;
    
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene == gameScene) 
        {
            startTime = Time.time;
            gameAccelerator = startAccelerator;
            maxAccelerator = MAX_ACCEL_PER_LEVEL[level];
            active = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime >= GAME_SECONDS && active)
        {
            level++;
            active = false;
            //end game
            //switch scene
        }
        else if (active)
        {
            gameAccelerator = (Time.time - startTime) / GAME_SECONDS * (maxAccelerator - startAccelerator) +
                              startAccelerator;
        }
    }
}
