using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBack : MonoBehaviour {

	public float speed;

	float posX;

	void Start() {
	}

	void FixedUpdate() {
		posX = transform.position.x;
		transform.position = new Vector3 (posX - speed, 
			transform.position.y,
			transform.position.z);

		if (transform.position.x <= -50) {
			transform.position = new Vector3 (39.9f, 
				transform.position.y,
				transform.position.z);
		}
	}
}
