using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour {
	public int Lefthitpoints;
	public int Righthitpoints;
	public int Bosshitpoints;
	// Use this for initialization
	void Start () {
		Lefthitpoints = 50;
		Righthitpoints = 50;
		Bosshitpoints = 20;
	}
	
	// Update is called once per frame
	void Update () {
		if (Lefthitpoints == 0 && Righthitpoints == 0) {
			transform.GetComponent<BoxCollider2D> ().enabled = true;
		}
		if(Bosshitpoints == 0 ){
			SceneManager.LoadScene ("Level06");
		}
	}
}
