using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonDialogue : MonoBehaviour
{
	public Button btn;
	public void Start()
	{
		btn.onClick.AddListener(TaskOnClick);
	}
	public void TaskOnClick()
	{
		SceneManager.LoadScene("Dialogue");
	}
}
