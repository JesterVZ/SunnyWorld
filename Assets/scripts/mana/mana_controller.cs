using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mana_controller : MonoBehaviour
{
    Rigidbody2D rb;
    private int force = 8;
    private int direction;

    // Use this for initialization
    void Start()
    {
        direction = Random.Range(1, 3);
        rb = GetComponent<Rigidbody2D>();
        if (direction == 1)
        {
            rb.AddForce(Vector2.left * force);
        }
        else
        {
            rb.AddForce(Vector2.right * force);
        }



    }

    // Update is called once per frame
    void Update()
    {

    }
}
