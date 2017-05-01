using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	Vector2 floatY;
	float originalY;

	public float floatStrength;

	void Start()
	{
		this.originalY = this.transform.position.y;
	}

	void Update()
	{
		transform.position = new Vector3(transform.position.x,
			originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
			transform.position.z);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			Destroy (coll.gameObject);
		}
	}
}
