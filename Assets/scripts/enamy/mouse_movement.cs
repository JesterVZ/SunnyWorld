using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse_movement : MonoBehaviour {
    private int speed = 1;
    private float timer;
    public bool facingRight;

    // Use this for initialization
    void Start () {
        facingRight = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {

        }
    }
}
