using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {

	public Button ChangeSceneButton;
	public int SceneToLoad;

	void Start () {
		Button btn = ChangeSceneButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Time.timeScale = 1;
		EditorSceneManager.LoadScene(SceneToLoad, UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
}
