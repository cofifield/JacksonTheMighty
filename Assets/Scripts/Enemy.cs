using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	public float destroyTime;
	public float health;
	public float damage;
	public float floatStrength;

	public AudioSource audio;

	public AudioClip hurt;

	float posX;
	float speed;
	float originalY;

	Vector2 floatY;

	void Start() {
		this.speed = Random.Range (minSpeed, maxSpeed);
		this.originalY = this.transform.position.y;
		Destroy (this.gameObject, destroyTime);
		audio.clip = hurt;
	}

	void FixedUpdate() {
		posX = transform.position.x;
		transform.position = new Vector3 (posX - speed, 
			originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
			transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		if (health <= 0) {
			Destroy(this.gameObject, hurt.length);
		}
			
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Bullet") {
			AudioSource.PlayClipAtPoint(hurt, transform.position);
			PlayerController pl = GameObject.Find("Player").GetComponent ("PlayerController") as PlayerController;
			//PlayerController pl = coll.gameObject.GetComponent ("PlayerController") as PlayerController;
			health -= pl.bulletDamage;
			Destroy (coll.gameObject);
		}
	}
}
