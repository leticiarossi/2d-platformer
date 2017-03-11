using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script that controls moving platforms.
 * 
 * To change where the platform moves to and form just need to change the position
 * of the platform object and the target objet, both children of the MovingPlatform prefab.
 *
 * Speed of platform can also be changed.
 */

public class MovingPlatformerController : MonoBehaviour {

	public Transform target;
	public float speed = 2f;

	Vector2 posA;
	Vector2 posB;

	void Start() {
		posA = transform.position;
		posB = target.position;
	}

	void Update() {
		// Move the platform
		float step = speed * Time.deltaTime;
		transform.position = Vector2.MoveTowards(transform.position, posB, step);
		if ((Vector2) transform.position == posB) {
			Vector2 temp = posB;
			posB = posA;
			posA = temp;
		}
	}

	// Make the player a child of the platformer so the player moves with it
	void OnCollisionEnter2D(Collision2D other) {
		if (other.collider.gameObject.tag == "Player") {
			other.transform.parent = transform;
		}
	}

}
