using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour {

	public GameObject UIPanel;

	void OnMouseDown(){
		UIPanel.SetActive (false);
	}
}
