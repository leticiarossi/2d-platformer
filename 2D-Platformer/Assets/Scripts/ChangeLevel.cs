using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class controls buttons used to change the scene that is being shown (next level, restart, etc)
 */

public class ChangeLevel : MonoBehaviour {

	public Button ChangeSceneButton; //the button used to change the scene
	public int SceneToLoad; //the int value of the scene to load

	void Start () {
		Button btn = ChangeSceneButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Time.timeScale = 1; //timeScale is changed to 0 when next "next level panel" appears, this undoes that
		Application.LoadLevel (SceneToLoad);
	}
}
