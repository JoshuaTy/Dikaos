using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
	public float speed = 0.05f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector2 (transform.position.x, transform.position.y + speed);
	
		if (transform.position.y >= 5.49) {
			speed = -0.05f;
		}
		if (transform.position.y <= -1.76f) {
			speed = 0.05f;
		}
	}
}
