using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to change the door to be open.
 */

public class DoorManager : MonoBehaviour {

	public Sprite spriteOpen;
	private SpriteRenderer sr; 

	void Awake () {
		sr = GetComponent<SpriteRenderer>();
	}

	public void OpenDoor() {
		sr.sprite = spriteOpen;
		tag = "OpenDoor";
	}
}
