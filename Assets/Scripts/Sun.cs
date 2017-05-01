using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

	public float RotateSpeed;
	public float Radius;

	Vector2 center;
	Vector2 offset;

	float angle;

	void Start()
	{
		center = transform.position;
	}

	void Update()
	{
		angle += RotateSpeed * Time.deltaTime;
		offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
		transform.position = center + offset;
	}
}
