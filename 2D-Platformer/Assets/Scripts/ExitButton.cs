using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class controls the exit button in the pause panel
 */

public class ExitButton : MonoBehaviour {

	public Button ExButton;

	void Start () {
		Button btn = ExButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene(0, LoadSceneMode.Single);
	}
}
