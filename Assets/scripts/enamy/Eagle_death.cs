using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle_death : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Equals("enamy")) {
			Destroy (col.gameObject);
		}
	}
}
