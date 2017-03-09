using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
	public static UIManager instance;
	public GameObject fadedKey;
	public GameObject filledInKey;

	void Awake(){
		instance = this;
		instance.fadedKey.SetActive (true);
		instance.filledInKey.SetActive (false);
	}

	public static void ShowKey(){
		instance.fadedKey.SetActive (false);
		instance.filledInKey.SetActive (true);
	}
}

