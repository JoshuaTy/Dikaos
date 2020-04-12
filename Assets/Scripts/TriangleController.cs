using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour {
	public LevelManagerController level;
	public GameObject projectile;
	public float projSpeed;
	public float speed;
	public Transform target;
	public float chaseRange;
	public float distanceToTarget;
	private Animator anim;
	public float shootCooldown;
	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
		level = FindObjectOfType<LevelManagerController> ();
		anim = GetComponent<Animator> ();
	}
	void Update(){
		if (shootCooldown > 0) {
			shootCooldown -= Time.deltaTime;
		}
	}


	// Update is called once per frame
	void FixedUpdate () {
		//if (level.isAlive) {
			distanceToTarget = Vector3.Distance (transform.position, target.position);

			if (transform.position.x < target.position.x) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}

			if (distanceToTarget < chaseRange) {
				Vector3 targetDir = target.position - transform.position;
				transform.Translate (targetDir.normalized * Time.deltaTime * speed);
				anim.SetFloat ("Speed", transform.position.x);
			}

		if(distanceToTarget > 10f){
			if (shootCooldown <= 0) {
				anim.SetTrigger ("Shoot");
				StartCoroutine (Shooting ());
			}
			}
		//}
	}

	IEnumerator Shooting(){
		shootCooldown += 5f;
		Vector2 targetTo = new Vector2 (target.position.x,target.position.y);
		Vector2 myPos = new Vector2 (transform.position.x, transform.position.y + 1);
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

