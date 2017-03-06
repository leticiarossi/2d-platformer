using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

	public GameObject UIPanel;

	void Start ()
	{
		UIPanel.SetActive (false);
	}
}
