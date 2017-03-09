using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public GameObject UIPanel1;
	public GameObject UIPanel2;
	public GameObject FilledInKey;

	void Start ()
	{
		UIPanel1.SetActive (false);
		UIPanel2.SetActive (false);
		FilledInKey.SetActive (false);
	}
}
