using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waiting : MonoBehaviour {
	public float waitime;
	// Use this for initialization
	void Start () {
		
		waitime = 5f;
		Camera.main.fieldOfView = 300;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
