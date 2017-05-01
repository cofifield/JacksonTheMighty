using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMover : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	public float destroyTime;

	float posX;
	float speed;

	void Start() {
		this.speed = Random.Range (minSpeed, maxSpeed);
		Destroy (this.gameObject, destroyTime);
	}

	void FixedUpdate() {
		posX = transform.position.x;
		transform.position = new Vector3 (posX - speed, 
			transform.position.y,
			transform.position.z);
	}
}
