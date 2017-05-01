using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

	public GameObject[] objects;

	public float maxOffsetY;
	public float maxOffsetX;

	public int secondsBetween;

	int objectChoice;

	float offsetX;
	float offsetY;
	float posX;
	float posY;
	float time;

	// Use this for initialization
	void Start () {
		this.posX = this.transform.position.x;
		this.posY = this.transform.position.y;
		this.objectChoice = 0;
		this.offsetX = 0;
		this.offsetY = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(Time.fixedTime % secondsBetween == 0) {
			if(objects.Length > 1)
			objectChoice = Random.Range (0, objects.Length);
			offsetX = Random.Range (-maxOffsetX, maxOffsetX);
			offsetY = Random.Range (-maxOffsetY, maxOffsetY);

			for (int i = 0; i < objects.Length; i++) {
				if(i == objectChoice) {
					GameObject spawnObject = objects [i];
					Instantiate (spawnObject);
					spawnObject.transform.position = new Vector3 (posX + offsetX, 
						posY + offsetY,
						transform.position.z);
				}
			}
		}
	}
}
