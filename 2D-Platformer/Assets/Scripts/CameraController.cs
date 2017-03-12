using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to have camera follow the player
 */

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraOffset;	//Stores the offset distance between the player and the camera

	void Start () {
		cameraOffset = transform.position - player.transform.position;
		
	}

	void LateUpdate () {
		transform.position = player.transform.position + cameraOffset;
	}

}
