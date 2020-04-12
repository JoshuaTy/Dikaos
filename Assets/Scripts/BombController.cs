using System.Collections;
using UnityEngine;

public class BombController : MonoBehaviour {
	public BossController hand;
	public Transform circle;
	public GameObject exp;
	// Use this for initialization
	void Start () {
		hand = FindObjectOfType<BossController> ();
		StartCoroutine (explode ());
	}
	
   // Update is called once per frame
	void Update () {
		
	}
	IEnumerator explode(){
		yield return new WaitForSeconds (3);
		Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
		GameObject explosion = (GameObject) Instantiate(exp,pos ,Quaternion.identity);
		Destroy (transform.gameObject);
	}

	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Circle") {
			if (target.gameObject.GetComponent<CircleController> ().splite == true) {
				Vector2 targetpos = new Vector2 (target.transform.position.x, target.transform.position.y);
				Debug.Log ("ey");
				Transform circle1 = (Transform)Instantiate (circle, targetpos, Quaternion.identity);
				Transform circle2 = (Transform)Instantiate (circle, targetpos, Quaternion.identity);
				circle1.GetComponent<CircleController> ().splite = false;
				circle2.GetComponent<CircleController> ().splite = false;
			}
				Destroy (target.gameObject);
				Vector2 pos = new Vector2 (this.transform.position.x, this.transform.position.y);
				GameObject explosion = (GameObject)Instantiate (exp, pos, Quaternion.identity);

				GameObject.Find ("EnemyText").GetComponent<EnemyTextController> ().updateNumberOfEnemiesLeft ();
				Destroy (transform.gameObject);
		
		}else if(target.gameObject.tag == "Triangle"){
			Debug.Log("ye");
			Destroy (target.gameObject);
			Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
			GameObject explosion = (GameObject) Instantiate(exp,pos ,Quaternion.identity);
			GameObject.Find ("EnemyText").GetComponent<EnemyTextController> ().updateNumberOfEnemiesLeft ();
			Destroy (transform.gameObject);
		}else if(target.gameObject.tag == "RightHand"){
			hand.Righthitpoints--;
			if (hand.Righthitpoints == 0) {
				Destroy (target.gameObject);
			}
			Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
			GameObject explosion = (GameObject) Instantiate(exp,pos ,Quaternion.identity);
			Destroy (transform.gameObject);
		}else if(target.gameObject.tag == "LeftHand"){
			hand.Lefthitpoints--;
			if (hand.Lefthitpoints == 0) {
				Destroy (target.gameObject);
			}
			Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
			GameObject explosion = (GameObject) Instantiate(exp,pos ,Quaternion.identity);
			Destroy (transform.gameObject);
		}
		else if(target.gameObject.tag == "Boss"){
			hand.Bosshitpoints--;
			if (hand.Bosshitpoints == 0) {
				Destroy (target.gameObject);
			}
			Vector2 pos = new Vector2(this.transform.position.x, this.transform.position.y);
			GameObject explosion = (GameObject) Instantiate(exp,pos ,Quaternion.identity);
			Destroy (transform.gameObject);
		}
	}


}
