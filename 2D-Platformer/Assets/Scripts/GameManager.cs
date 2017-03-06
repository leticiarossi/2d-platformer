﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraOffset;	//Stores the offset distance between the player and the character


	// Use this for initialization
	void Start () {
		cameraOffset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void LateUpdate() {
		transform.position = player.transform.position + cameraOffset;
	}
}