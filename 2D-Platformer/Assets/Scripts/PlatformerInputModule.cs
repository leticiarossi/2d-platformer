﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to manage player's input. Code from the script seen in class.
 */

[RequireComponent(typeof(PlatformerController))]
public class PlatformerInputModule : MonoBehaviour {

	PlatformerController controller;

	void Start()
	{
		controller = GetComponent<PlatformerController>();
	}

	void Update()
	{
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (input.magnitude > 1) {
			input.Normalize();
		}
		controller.input = input;
		controller.inputJump = Input.GetButtonDown("Jump");
	}
}
