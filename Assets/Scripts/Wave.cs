using System.Collections;
using UnityEngine;

public class Wave : MonoBehaviour {

	float originalY;
	float originalX;

	public bool flip;

	void Start() {
		this.originalY = this.transform.position.y;
		this.originalX = this.transform.position.x;
	}

	void FixedUpdate() {

		if (flip) {
			transform.position = new Vector3 (originalX + ((float)Mathf.Cos (Time.time)), 
				originalY + ((float)Mathf.Cos (Time.time)),
				transform.position.z);
			
		} else {
			transform.position = new Vector3 (originalX - ((float)Mathf.Sin (Time.time)), 
				originalY + ((float)Mathf.Sin (Time.time)),
				transform.position.z);
		}
	}

}
