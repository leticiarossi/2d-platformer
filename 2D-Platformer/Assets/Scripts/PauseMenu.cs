using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public GameObject UIPanel1;
	public GameObject UIPanel2;

	void Start ()
	{
		UIPanel1.SetActive (false);
		UIPanel2.SetActive (false);
	}
}
