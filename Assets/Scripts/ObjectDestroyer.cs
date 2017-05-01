using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour {

	public string[] tagsToDestroy;

	void OnCollisionEnter2D(Collision2D col) {
		for (int i = 0; i < tagsToDestroy.Length; i++) {
			if(col.gameObject.tag == tagsToDestroy[i]){
				Destroy (col.gameObject);	
			}
		}
	}
}
