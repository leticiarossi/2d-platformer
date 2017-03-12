using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

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
		if (scene < 8) {
			instance.NextLevelPanel.SetActive (true);
			Time.timeScale = 0; //pause background when panel is present
		} else {
			EditorSceneManager.LoadScene (9, UnityEngine.SceneManagement.LoadSceneMode.Single);
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
