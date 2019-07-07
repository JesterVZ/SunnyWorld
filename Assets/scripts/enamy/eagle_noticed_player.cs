using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class eagle_noticed_player : MonoBehaviour {
	public GameObject attack;
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Equals("player")) {
			Instantiate (attack, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
