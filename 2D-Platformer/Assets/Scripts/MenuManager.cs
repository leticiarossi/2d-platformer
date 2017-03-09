using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public static void LevelDone(){
		instance.NextLevelPanel.SetActive (true);
		Time.timeScale = 0;
	}

	public static void EnablePause(){
		instance.PauseMenu.SetActive (true);
		Time.timeScale = 0;
	}

	public static void DisablePause(){
		instance.PauseMenu.SetActive (false);
		Time.timeScale = 1;
	}
}
