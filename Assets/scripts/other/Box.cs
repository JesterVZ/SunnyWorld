using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {
	private int NumberOfStrokes, item_index;
	public GameObject[] items = new GameObject[5];
	// Use this for initialization
	void Start () {
		NumberOfStrokes = Random.Range(2,15);
		item_index = Random.Range (0, 4);
		Debug.Log (NumberOfStrokes);
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name.Equals("player")) {
			NumberOfStrokes--;
			Debug.Log (NumberOfStrokes);
		}
		if (NumberOfStrokes == 0) {
			Instantiate (items[item_index], new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
