using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMovement : MonoBehaviour {

	public float horizontalSpeed;
	public float verticalSpeed;
	public float amplitude;

	Vector3 tempPosition;

	bool flip;

	float rand;

	void Start () 
	{
		tempPosition = transform.position;
		flip = false;
		rand = Random.Range (0f, 1f);
	}

	void FixedUpdate () {

		if (flip) {
			tempPosition.x -= horizontalSpeed;
			tempPosition.y = Mathf.Sin (Time.realtimeSinceStartup * verticalSpeed) * (amplitude + rand);
			transform.position = tempPosition;
		} else {
			tempPosition.x += horizontalSpeed;
			tempPosition.y = Mathf.Sin (Time.realtimeSinceStartup * verticalSpeed) * (amplitude + rand);
			transform.position = tempPosition;
		}

		if (transform.position.x >= 25) {
			flip = true;
			transform.rotation = new Quaternion(0f,180f,0f,0f);
			rand = Random.Range (0f, 2f);
		}
		
		if (transform.position.x <= -25) {
			flip = false;
			transform.rotation = new Quaternion(0f,0f,0f,0f);
			rand = Random.Range (0f, 2f);
		}
	}
}
