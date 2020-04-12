using UnityEngine;
using System.Collections;

public class CircleController : MonoBehaviour {
	
	public Transform circle;
	public LevelManagerController level;
	public float distanceToTarget;
	public Transform target;//set target from inspector instead of looking in Update
	public float speed = 3f;
	public float chaseRange = 5f;
	private Animator anim;
	public bool splite = true;

	void Start () {
		target = FindObjectOfType<PlayerController>().GetComponent<Transform>();
		level = FindObjectOfType<LevelManagerController> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		//if (level.isAlive) {
			distanceToTarget = Vector3.Distance (transform.position, target.position);
			if (transform.position.x < target.position.x) {
				transform.localScale = new Vector3 (1f, 1f, 1f);
			} else {
				transform.localScale = new Vector3 (-1f, 1f, 1f);
			}
			if (distanceToTarget < chaseRange) {
				transform.position = Vector3.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
				anim.SetFloat ("Speed", 1f);
			} else {
				anim.SetFloat ("Speed", -1f);
			}

		if(transform.position.y < -15f){
			GameObject.Find ("EnemyText").GetComponent<EnemyTextController> ().updateNumberOfEnemiesLeft ();
			Destroy (transform.gameObject);
		}
		//}
	}

}