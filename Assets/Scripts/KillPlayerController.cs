using UnityEngine;
using System.Collections;

public class KillPlayerController : MonoBehaviour {
	public LevelManagerController levelManager;


	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManagerController> ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			GameObject.Find ("Main Camera").GetComponent<Menu>().showMenu() ;
			//levelManager.RespawnPlayer();
		
		}
	}
}
