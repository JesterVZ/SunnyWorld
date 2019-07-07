using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frog_movement : MonoBehaviour
{
    public float speed, jumpPower;
    Rigidbody2D rb;
    public bool facingRight;
    private int randomPath;

    const string c = "(Clone)";

    public bool IsGrounded;
    public Transform groundCheck;
    private float CheckRadius, timer;
    public LayerMask WhatIsGround;
    public GameObject Mana;

    void Start()
    {

        randomPath = Random.Range(0, 2);
        CheckRadius = 0.1f;
        rb = GetComponent<Rigidbody2D>();
        jumpPower = Random.Range(20, 60);
        speed = 0.5f;
        timer = Random.Range(0.5f, 2f);
        facingRight = false;

    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            
            if (IsGrounded)
            {
                Jump();
                Reload();
            }
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpPower);
        if (randomPath == 1)
        {
            rb.AddForce(Vector2.left * (jumpPower + 3));
        }
        else
        {
            rb.AddForce(Vector2.right * (jumpPower + 3));
        }
    }
    private void Reload()
    {
        randomPath = Random.Range(0, 2);
        timer = Random.Range(1f, 3f);
        jumpPower = Random.Range(20, 60);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            case "fireball 1" + c:
                for(int i = 0; i < 3; i++)
                {
                    Instantiate(Mana, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                }
                    Destroy(gameObject);
                break;
        }
    }

    void FixedUpdate()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, WhatIsGround);
    }

}
