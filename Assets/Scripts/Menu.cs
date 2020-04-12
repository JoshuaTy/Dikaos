using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Menu : MonoBehaviour {
	private bool isShowing;

	public GameObject menuBackground;
	public GameObject gameoverText;
	public GameObject retryButton;
	public GameObject quitButton;

	// Use this for initialization
	void Start () {
		Debug.Log ("ad");
		menuBackground.SetActive (isShowing);
		gameoverText.SetActive (isShowing);
		retryButton.SetActive (isShowing);
		quitButton.SetActive (isShowing);
	}

	public void showMenu(){
		Debug.Log ("baby");
		Time.timeScale = 0;
		isShowing = !isShowing;
		menuBackground.SetActive (isShowing);
		gameoverText.SetActive (isShowing);
		retryButton.SetActive (isShowing);
		quitButton.SetActive (isShowing);
	}

}
