using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public PlayerController Player;
	public bool isFollowing;
	public float XOffset;
	public float YOffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<PlayerController> ();
		isFollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isFollowing){
			transform.position = new Vector3 (Player.transform.position.x + XOffset, Player.transform.position.y + YOffset,-20);
		}

		if (transform.position.x <= -0.9f) {
			if (transform.position.y <= -0.4f) {
				transform.position = new Vector3 (-0.9f, -0.4f + YOffset, -20);
			} else {
				transform.position = new Vector3 (-0.9f,  Player.transform.position.y + YOffset, -20);
			}
			//2.7f

		}
		if (transform.position.y <= -0.4f) {
			
			transform.position = new Vector3 (Player.transform.position.x + XOffset, -0.4f, -20);
		}

		if(transform.position.x >= 40.5f){
			/*For the bottom right screen*/
			if (transform.position.y <= -0.3f) {
				transform.position = new Vector3 (40.5f,  -0.3f, -20);
			} else if(transform.position.y >=11.5f){
				transform.position = new Vector3 (40.5f,  11.5f, -20);
			}else {
				transform.position = new Vector3 (40.5f,  Player.transform.position.y + YOffset, -20);
			}

				
		}
		if(transform.position.y >= 11.5f){
			if(transform.position.x >= 40.5f){
				//TOP RIGHT
				transform.position = new Vector3 (40.5f,  11.5f, -20);
			}else if (transform.position.x <= 2.7f) {
				//TOP LEFT
				transform.position = new Vector3 (2.7f,  11.5f, -20);
			} else {
				
				transform.position = new Vector3 (Player.transform.position.x + XOffset, 11.5f, -20);
			}

		}
	}
}
