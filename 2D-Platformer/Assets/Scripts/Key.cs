using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script to animate the key. 
 */

public class Key : MonoBehaviour {

	void Update(){
		float scaleX = Mathf.Sin(Time.time * 3);
		transform.localScale = new Vector3(scaleX, 1 , 1);
	}
}
