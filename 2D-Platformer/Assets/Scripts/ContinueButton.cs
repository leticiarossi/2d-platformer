using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class controls the continue button within the pause panel
 */
public class ContinueButton : MonoBehaviour {

	public Button continueButton; 

	void Start () {
		Button btn = continueButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		MenuManager.DisablePause (); //references menu manager class using a singleton pattern
	}
}
