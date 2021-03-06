﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Script to manage things related to the player like placing and picking up
 * blocks, player's death and player's interactions with key and door.
 */ 

[RequireComponent(typeof(PlatformerController))]
public class PlayerManager : MonoBehaviour {

	public Transform pickUpBlock;
	public int sceneToLoad;
	public CameraController cameraController;
	public AudioClip blockSound;
	public AudioClip keySound;
	public AudioClip finishLevelSound;
	public AudioClip startLevelSound;

	float lowestPlatformPos;
	AudioSource source;

	PlatformerController controller;
	CircleCollider2D groundCollider;

	int sizeOfPlayer = 1; // Number of blocks that player is made of 
	int minSize = 1;
	int maxSize = 4;

	GameObject[] blocksArray = new GameObject[4]; // Reference to blocks of the player
	float[] groundColliderPos = {-0.03f, -1.03f, -2.03f, -3.03f};

	void Start () {
		source = GetComponent<AudioSource> ();
		controller = GetComponent<PlatformerController>();
		groundCollider = controller.groundCollider;
		for (int i = 1; i < blocksArray.Length; i++) {
			blocksArray [i] = GameObject.FindGameObjectWithTag ("Block" + i);
			blocksArray [i].gameObject.SetActive (false);
		}

		// Play start of level sound
		source.clip = startLevelSound;
		source.volume = 1f;
		source.pitch = 1f;
		source.PlayOneShot (startLevelSound);

		// Set position of lowest object for reference of dying
		GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
		lowestPlatformPos = float.PositiveInfinity; 
		foreach (GameObject platform in platforms) {
			if (platform.transform.position.y < lowestPlatformPos) {
				lowestPlatformPos = platform.transform.position.y;
			}
		}
	}

	void Update () {
		if (Input.GetButtonDown ("PlaceBlock")) {
			DecreaseSize ();
		} else if (Input.GetButtonDown ("PickUpBlock") && IsOnPickUpBlock()) {
			IncreaseSize ();
		}

		// Character dies
		if (controller.transform.position.y <= lowestPlatformPos - 8) {
			// Freeze camera
			cameraController.enabled = false;
		}

		if (controller.transform.position.y <= lowestPlatformPos - 30) {
			// Reload scene
			Application.LoadLevel (sceneToLoad);
		}
	}
		
	// Check if player gets to the key/door and manage opening door
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Key")) {
			// Get key
			other.gameObject.SetActive (false);
			// Play sound
			source.clip = keySound;
			source.volume = 1f;
			source.pitch = 1f;
			source.PlayOneShot (keySound);
			//Update UI
			UIManager.ShowKey();
			// Open door
			GameObject door = GameObject.FindGameObjectWithTag("ClosedDoor");
			DoorManager doorMngr = door.GetComponent<DoorManager> ();
			doorMngr.OpenDoor ();
		} else if (other.gameObject.CompareTag ("OpenDoor")) {
			// Play sound
			source.clip = finishLevelSound;
			source.volume = 1f;
			source.pitch = 1f;
			source.PlayOneShot (finishLevelSound);
			// Finish level
			MenuManager.LevelDone(sceneToLoad - 1);
		}
	}

	// Update player when it places a block
	void DecreaseSize () {
		if (sizeOfPlayer > minSize) {
			// Play sound
			source.clip = blockSound;
			source.volume = 1f;
			source.pitch = 1.1f;
			source.PlayOneShot (blockSound);

			// Update player
			sizeOfPlayer--;
			PlacePickUpBlock ();
			blocksArray [sizeOfPlayer].gameObject.SetActive (false);

			// Change position of ground collider
			float offsetX = groundCollider.offset.x;
			groundCollider.offset = new Vector2 (offsetX, groundColliderPos[sizeOfPlayer-1]);
		}
	}

	// Update player when it picks up a block
	void IncreaseSize () {
		if (sizeOfPlayer < maxSize) {
			// Play sound
			source.clip = blockSound;
			source.volume = 1f;
			source.pitch = 0.8f;
			source.PlayOneShot (blockSound);

			// Update player
			blocksArray [sizeOfPlayer].gameObject.SetActive (true);
			sizeOfPlayer++;
			RemovePickUpBlock ();

			// Change position of ground collider
			float offsetX = groundCollider.offset.x;
			groundCollider.offset = new Vector2 (offsetX, groundColliderPos[sizeOfPlayer-1]);
		}
	}

	// Place a pickup block where player pressed space
	void PlacePickUpBlock() {
		float x = blocksArray [sizeOfPlayer].gameObject.transform.position.x;
		float y = blocksArray [sizeOfPlayer].gameObject.transform.position.y;

		Instantiate(pickUpBlock, new Vector2(x, y), Quaternion.identity);
	}

	// Check if player is on top of a pickup block
	bool IsOnPickUpBlock () {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag ("PickUp");
		foreach (GameObject pickup in pickups) {
			if (groundCollider.IsTouching (pickup.GetComponent<BoxCollider2D>())) {
				return true;
			}
		}
		return false;
	}

	// Remove the pickup block that the player was on top of from the scene
	void RemovePickUpBlock() {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag ("PickUp");
		foreach (GameObject pickup in pickups) {
			if (groundCollider.IsTouching (pickup.GetComponent<BoxCollider2D>())) {
				Destroy (pickup);
			}
		}
	}
		
}
