using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
	private LevelManagerController levelManager;
	private int flag = 0;

	// Use this for initialization
	void Start () {
		levelManager = FindObjectOfType<LevelManagerController> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D target){
		if(target.gameObject.tag=="Player"){
			if(flag==0){
				levelManager.currentCheckpoint = gameObject;
				flag=1;
			}
			Debug.Log ("Activated");
		}
	}
}
