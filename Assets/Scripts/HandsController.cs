using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsController : MonoBehaviour {
	public Transform target;
	public Transform dangRocks;
	public GameObject projectile;
	public float projSpeed = 3f;
	public int choose = 0;
	public float actioncooldown;
	public Transform grounds;
	public float moveSpeed = 0.1f;
	public float upperbound = 4.04f;
	public float lowerbound = -1.48f;
	public float shootCooldown;
	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
		actioncooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}


		if(actioncooldown >= 0) {
			actioncooldown -= Time.deltaTime;
		}
		if (actioncooldown < 0) {
			choose = (choose + 1) % 3;
			actioncooldown = 8f;
		}
		if (choose == 1) {
			StartCoroutine (Slam ());
		} else if (choose == 0) {
			if (shootCooldown <= 0) {
				Fireball ();
			}
		}
	}
	IEnumerator Slam(){
		yield return new WaitForSeconds (1);
		if (actioncooldown >= 0) {
			transform.position = new Vector2 (transform.position.x, transform
				.position.y + moveSpeed);
			if (transform.position.y >= 4.04f) {
				moveSpeed = -0.1f;
			}
			if (transform.position.y <= -1.48) {
				Instantiate (grounds, new Vector2 (transform.position.x, -1.48f), Quaternion.identity);
				Instantiate (dangRocks, new Vector2(target.position.x+1, target.position.y + 10f),Quaternion.identity);
				moveSpeed = 0.1f;
			}
		}
	}
	public void Fireball(){
		if (actioncooldown >= 0) {
			transform.position = new Vector2 (transform.position.x, transform
				.position.y + moveSpeed);
			if (transform.position.y >= 4.04f) {
				transform.position = new Vector2 (transform.position.x, 4.04f);
			}
			StartCoroutine (Shooting());

		}
	}
	IEnumerator Shooting(){
		shootCooldown += 2f;
		Vector2 targetTo = new Vector2 (target.position.x,target.position.y - 1.3f);
		Vector2 myPos = new Vector2 (transform.position.x, transform.position.y);
		Vector2 direction = targetTo - myPos;
		direction.Normalize ();
		GameObject projectileYellow = (GameObject)Instantiate (projectile, myPos, Quaternion.identity);
		if (target.transform.position.x < projectileYellow.gameObject.transform.position.x) {
			projectileYellow.gameObject.transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			projectileYellow.gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
		}
		projectileYellow.GetComponent<Rigidbody2D>().velocity = direction * projSpeed;
		yield return new WaitForSeconds (5);
		Destroy (projectileYellow);	
	}
}
