using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresserController : MonoBehaviour {

	Rigidbody2D rb2d;

	void Start () {
		
	}

	void Update () {
		Vector3 pos = transform.position; 
		pos.y -= 0.3f; 
		transform.position = pos; 
	}

}
