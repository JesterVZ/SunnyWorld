using UnityEngine;

public class explosion : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Destroy(gameObject, 0.1f);
	}
}
