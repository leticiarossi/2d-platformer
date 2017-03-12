using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class manages the various UI menus throughout the game using a singleton pattern
 */

public class MenuManager : MonoBehaviour
{

	public static MenuManager instance;
	public GameObject PauseMenu;
	public GameObject NextLevelPanel;

	void Awake ()
	{
		instance = this;
		PauseMenu.SetActive (false);
		NextLevelPanel.SetActive (false);
	}

	public static void LevelDone(int scene){
		if (scene < 7) {
			instance.NextLevelPanel.SetActive (true);
			Time.timeScale = 0; //pause background when panel is present
		} else {
			Application.LoadLevel (9);
		}
	}

	public static void EnablePause(){
		instance.PauseMenu.SetActive (true);
		Time.timeScale = 0; //pause background when panel is present
	}

	public static void DisablePause(){
		instance.PauseMenu.SetActive (false);
		Time.timeScale = 1; //unpause background when panel goes away
	}
}
