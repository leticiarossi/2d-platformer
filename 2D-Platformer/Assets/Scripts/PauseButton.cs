using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class controls the pause button in the UI
 */

public class PauseButton : MonoBehaviour {

		public Button pauseButton;

		void Start () {
			Button btn = pauseButton.GetComponent<Button>();
			btn.onClick.AddListener(TaskOnClick);
		}

		void TaskOnClick(){
			MenuManager.EnablePause ();
		}
	}
