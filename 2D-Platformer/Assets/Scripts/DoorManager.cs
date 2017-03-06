using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour {

	public Sprite spriteOpen;

	private SpriteRenderer sr; 

	void Start () {
		sr = GetComponent<SpriteRenderer>();
	}
	
	public void OpenDoor() {
		sr.sprite = spriteOpen;
		tag = "OpenDoor";
	}
}
