using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatUpgrade : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	public float destroyTime;
	public float floatStrength;

	float posX;
	float speed;
	float originalY;

	Vector2 floatY;

	void Start() {
		this.speed = Random.Range (minSpeed, maxSpeed);
		this.originalY = this.transform.position.y;
		Destroy (this.gameObject, destroyTime);
	}

	void FixedUpdate() {
		posX = transform.position.x;
		transform.position = new Vector3 (posX - speed, 
			originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
			transform.position.z);
	}
}
