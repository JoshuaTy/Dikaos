using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destry());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator destry(){
		yield return new WaitForSeconds (1);
		Destroy (gameObject);
	}
}
