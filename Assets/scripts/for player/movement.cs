using UnityEngine;


public class movement : MonoBehaviour {
	private int speed, jumpPower;
	public int fireball_count, mana_count;
	public bool facingRight;
	public float moveX;
	public  Animator animator;


	private FoxState state{
		get{ return (FoxState)animator.GetInteger ("state");}
		set{ animator.SetInteger ("state", (int) value); }
	}

	public bool IsGrounded;
	public Transform groundCheck;
	public float CheckRadius;
	public LayerMask WhatIsGround;
	public GameObject fireball;

	void Start () {
        animator = GetComponent<Animator> ();
		speed = 1;
		facingRight = false;
		jumpPower = 6;
		PlayerMove ();
	}

	void Update () {
		state = FoxState.Idle;
		if (Input.GetAxis ("Horizontal") != 0) {
			state = FoxState.Run;
		}
		if (IsGrounded == false) {
			state = FoxState.Jump;

		}
		PlayerMove ();
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			speed++;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = 1;
		}
		if (Input.GetKeyDown (KeyCode.F)) {
            if(mana_count > 0)
            {
                if (fireball_count > 0)
                {
                    Instantiate(fireball, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    fireball_count--;
                    mana_count = mana_count - 2;
                }
            }
			
		}

	}

	void FixedUpdate(){
		IsGrounded = Physics2D.OverlapCircle (groundCheck.position, CheckRadius, WhatIsGround);
	}

	void PlayerMove(){

		moveX = Input.GetAxis("Horizontal");
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}

		if (Input.GetButtonDown ("Jump")) {
			
			Jump ();
		}

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * speed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}

	void FlipPlayer(){
		facingRight = !facingRight;
		Vector2 localscale = gameObject.transform.localScale;
		localscale.x *= -1;
		transform.localScale = localscale;
	}

	void Jump(){
		if (IsGrounded == true) {
			GetComponent<Rigidbody2D> ().AddForce (Vector2.up * jumpPower);
		}

	}


}
public enum FoxState
{
	Idle,
	Run,
	Jump
}