using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

[RequireComponent(typeof(PlatformerController))]
public class PlayerManager : MonoBehaviour {

	public Transform pickUpBlock;
	public int sceneToLoad;
	public CameraController cameraController;

	private float lowestPlatformPos;

	PlatformerController controller;
	CircleCollider2D groundCollider;

	int sizeOfPlayer = 1; // Number of blocks that player is made of 
	int minSize = 1;
	int maxSize = 4;

	GameObject[] blocksArray = new GameObject[4]; // Reference to blocks of the player
	float[] groundColliderPos = {-0.03f, -1.03f, -2.03f, -3.03f};

	void Start () {
		controller = GetComponent<PlatformerController>();
		groundCollider = controller.groundCollider;
		for (int i = 1; i < blocksArray.Length; i++) {
			blocksArray [i] = GameObject.FindGameObjectWithTag ("Block" + i);
			blocksArray [i].gameObject.SetActive (false);
		}

		//set position of lowest object for reference of dying
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

		if (controller.transform.position.y <= lowestPlatformPos - 8) {
			//Freeze camera
			cameraController.enabled = false;

		}
		if (controller.transform.position.y <= lowestPlatformPos - 30) {
			//Reload scene
			EditorSceneManager.LoadScene(sceneToLoad, UnityEngine.SceneManagement.LoadSceneMode.Single);
		}
	}
		
	// Check if player gets to the key/door and manage opening door
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.CompareTag ("Key")) {
			// Get key
			other.gameObject.SetActive (false);
			//Update UI
			UIManager.ShowKey();
			// Open door
			GameObject door = GameObject.FindGameObjectWithTag("ClosedDoor");
			DoorManager doorMngr = door.GetComponent<DoorManager> ();
			doorMngr.OpenDoor ();
		} else if (other.gameObject.CompareTag ("OpenDoor")) {
			// Finish level
			MenuManager.LevelDone();
		}
	}

	// Update player when it places a block
	void DecreaseSize () {
		if (sizeOfPlayer > minSize) {
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

	// Checks if player is on top of a pickup block
	bool IsOnPickUpBlock () {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag ("PickUp");
		foreach (GameObject pickup in pickups) {
			if (groundCollider.IsTouching (pickup.GetComponent<BoxCollider2D>())) {
				return true;
			}
		}
		return false;
	}

	// Removes the pickup block that the player was on top on from the scene
	void RemovePickUpBlock() {
		GameObject[] pickups = GameObject.FindGameObjectsWithTag ("PickUp");
		foreach (GameObject pickup in pickups) {
			if (groundCollider.IsTouching (pickup.GetComponent<BoxCollider2D>())) {
				Destroy (pickup);
			}
		}
	}
		
}
