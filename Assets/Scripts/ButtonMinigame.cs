using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonMinigame : MonoBehaviour
{
	public Button btn;
 	public void Start()
 	{
 		btn.onClick.AddListener(TaskOnClick);
 	}

    public void TaskOnClick()
    {
	    SceneManager.LoadScene("Minigame");
    }
}
