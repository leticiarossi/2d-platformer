using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

	void Update(){
		// Sine and Cosine functions are a nice way to create smooth animations in code
		// alternatively a animation can be created
		float scaleX = Mathf.Sin(Time.time * 3);
		// due to the way the scale effects children and objects in the hiearchy, only the objects local scale can be changed on runtime
		transform.localScale = new Vector3(scaleX, 1 , 1);
	}
}
