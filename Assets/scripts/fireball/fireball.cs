using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour {
	Rigidbody2D rb;
	movement m;
	private int power;
	private float timer = 2f;
	public GameObject explosion;
	// Use this for initialization
	void Start () {
		power = 200;
		m = FindObjectOfType<movement>();
		rb = GetComponent<Rigidbody2D> ();
		if (m.facingRight) {
			rb.AddForce (Vector2.left * power);
		} else {
			rb.AddForce (Vector2.right * power);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer > 0) {
			timer -= Time.deltaTime;
		}
		if (timer <=0) {
			Instantiate (explosion, new Vector3 (transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
			Destroy (gameObject);
		}
	}
}
