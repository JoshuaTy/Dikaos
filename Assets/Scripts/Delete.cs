using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (destrey());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator destrey(){
		yield return new WaitForSeconds (2);
		Destroy (gameObject);
	}
}
