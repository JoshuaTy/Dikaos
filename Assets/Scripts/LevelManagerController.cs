using UnityEngine;
using System.Collections;

public class LevelManagerController : MonoBehaviour {
	public GameObject currentCheckpoint;
	public GameObject player;
	public GameObject deathParticle;
	public GameObject respawnParticle;
	public float respawnDelay;
	public int pointPenaltyOnDeath;
	private float playerGravity;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.y < -15f) {
			Debug.Log ("Player fell");
			Destroy (player);
			GameObject.Find ("Main Camera").GetComponent<Menu>().showMenu() ;

		}
	}
	public void RespawnPlayer(){
		//player.transform.position = currentCheckpoint.transform.position;
		Debug.Log("Respawning");
		StartCoroutine("RespawnPlayerCo");
	}
	public IEnumerator RespawnPlayerCo(){
		Instantiate (deathParticle,player.transform.position, player.transform.rotation);
		player.GetComponent<PlayerController>().enabled = false;
		player.GetComponent<Renderer>().enabled=false;
		Debug.Log ("Player Respawn");
		player.GetComponent<Rigidbody2D> ().velocity = Vector2.zero; //sets the velocity to 0 both x and y when the player is dead.

		playerGravity = player.GetComponent<Rigidbody2D>().gravityScale;
		player.GetComponent<Rigidbody2D>().gravityScale=0f;

		yield return new WaitForSeconds (respawnDelay);

		player.GetComponent<Rigidbody2D>().gravityScale=playerGravity;
		player.transform.position = currentCheckpoint.transform.position;
		player.GetComponent<PlayerController>().enabled= true;
		player.GetComponent<Renderer>().enabled= true;
		Instantiate (respawnParticle, player.transform.position, player.transform.rotation);
	}
}



