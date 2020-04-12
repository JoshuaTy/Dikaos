using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {
	public float speed=0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector2 (transform.position.x + speed,transform.position.y);
		if (transform.position.x >= 3.3f) {
			speed = -0.2f;
		}
		if(transform.position.x <= -8.3f){
			speed = 0.2f;
		}
	}
}
