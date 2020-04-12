using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTextController : MonoBehaviour {
	public GameObject portal;
	public Transform portalspawner;
	public int EnemyCount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetComponent<Text> ().text = "Enemies Left: " + EnemyCount.ToString();
	}

	public void updateNumberOfEnemiesLeft(){
		
		if (EnemyCount >0) {
			EnemyCount--;
		}
		GetComponent<Text> ().text = "Enemies Left:  " + EnemyCount.ToString ();
		if (EnemyCount == 0) {
			Vector2 pos = new Vector2 (portalspawner.position.x, portalspawner.position.y);
			Instantiate (portal, pos, Quaternion.identity);
			portal.transform.position = GameObject.Find ("SpawnPortal").GetComponent<Transform> ().position;
		} 
	}
}
