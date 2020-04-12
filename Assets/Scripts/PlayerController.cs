using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject bomb;
	public float speed = 5.0f;


	public float jumpHeight;
	public float moveSpeed;
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	private bool doubleJumped;
	private Animator anim;
	private float moveVelocity;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		

		grounded = Physics2D.OverlapCircle (groundCheck.position,groundCheckRadius,whatIsGround);
		if (grounded) {
			doubleJumped = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown (KeyCode.W)  && grounded) {
			Jump ();
		}
		if (Input.GetKeyDown (KeyCode.Space)||Input.GetKeyDown (KeyCode.W) && !doubleJumped && !grounded) {
			Jump ();
			doubleJumped = true;
		}


		

		moveVelocity = 0f;
		if(Input.GetKey(KeyCode.D)){
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerThrowing")){
				anim.Play("PlayerWalking");
			}
			moveVelocity = moveSpeed;
		}
		if(Input.GetKey(KeyCode.A)){
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("PlayerThrowing")){
				anim.Play("PlayerWalking");
			}
			moveVelocity = -moveSpeed;
		}
		GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveVelocity,GetComponent<Rigidbody2D>().velocity.y);

		anim.SetFloat ("Speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
		anim.SetBool ("Grounded",grounded);
		//Flipping
		if(GetComponent<Rigidbody2D>().velocity.x > 0){
			transform.localScale = new Vector3 (1f,1f,1f);
		}else if(GetComponent<Rigidbody2D>().velocity.x < 0){
			transform.localScale = new Vector3 (-1f,1f,1f);
		}


		if (Input.GetMouseButtonDown (0)) {
			anim.SetTrigger ("Throw");
			Vector2 target = Camera.main.ScreenToWorldPoint (new Vector2 (Input.mousePosition.x,Input.mousePosition.y));
			Vector2 myPos = new Vector2 (transform.position.x, transform.position.y + 1);
			Vector2 direction = target - myPos;
			direction.Normalize ();
			GameObject projectile = (GameObject)Instantiate (bomb, myPos, Quaternion.identity);
			projectile.GetComponent<Rigidbody2D>().velocity = direction * speed;
		}


	}


	public void Jump(){
		GetComponent<Rigidbody2D> ().velocity
		= new Vector2 (GetComponent<Rigidbody2D>().velocity.x,
			jumpHeight
		);
	}

	void OnCollisionEnter2D(Collision2D target){
		if (grounded && target.gameObject.tag == "Obstacle") {
			transform.position = target.transform.position;
		}
	}
}