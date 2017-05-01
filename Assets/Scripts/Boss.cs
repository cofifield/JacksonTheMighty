using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public float RotateSpeed;
	public float Radius;

	Vector2 center;
	Vector2 offset;

	float angle;

	public float floatStrength;
	public float health;

	public GameObject hannah;

	public AudioClip hurt;

	// Use this for initialization
	void Start () {
		center = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		angle += RotateSpeed * Time.deltaTime;
		offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
		transform.position = center + offset;

		if (health <= 0) {
			Instantiate (hannah);
			hannah.gameObject.transform.position = new Vector3 (13.15f, -4.83f, 0f);
			Destroy(this.gameObject);
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
