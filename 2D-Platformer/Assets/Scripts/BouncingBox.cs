using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBox : MonoBehaviour {

	Rigidbody2D rb;
	public float force;

	void Start(){
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		rb.AddForce (transform.right * force);
		if (Time.timeSinceLevelLoad > 1.5) {
			force = 0;
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.CompareTag("Wall")){
			force *= -1;
		}
	}
}
