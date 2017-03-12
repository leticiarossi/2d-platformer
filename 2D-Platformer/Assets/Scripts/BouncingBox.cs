using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This Class controls the bouncing block animation on the main menu. 
 */

public class BouncingBox : MonoBehaviour {

	Rigidbody2D rb;
	public float force; //amount of force to be applied to block

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> (); //get the component
	}

	void FixedUpdate(){
		rb.AddForce (transform.right * force);
		if (Time.timeSinceLevelLoad > 1.5) { //apply for 1.5 seconds so the block doesn't start bouncing too fast
			force = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){ //when block hits a wall, the force is reversed
		if (coll.gameObject.CompareTag("Wall")){
			force *= -1;
		}
	}
}
