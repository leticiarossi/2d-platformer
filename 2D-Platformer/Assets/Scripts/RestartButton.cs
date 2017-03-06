using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour {

	public Button restartButton;

	void Start () {
		Button btn = restartButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		int scene = EditorSceneManager.GetActiveScene().buildIndex;
		EditorSceneManager.LoadScene(scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
	}
}
