using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour {
	public Object NextsceneName;
	public Object CurrentsceneName;

	/*
	public Object sceneName;
	// Use this for initialization

	
	}*/
	void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Player") {
			StartCoroutine (loadlevel ());

		}
	}
	IEnumerator loadlevel(){
		float fadeTime = GameObject.Find ("Main Camera").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		ChangeSceneForMainMenu ();
	}

	public void Retry(){
		int c = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene(c);

		Time.timeScale = 1;
	}
	public void nextScene(){
		int c = SceneManager.GetActiveScene ().buildIndex;
		SceneManager.LoadScene(c);
		SceneManager.LoadScene (NextsceneName.name);
	}
	public void exit(){
		Application.Quit ();
	}
	public void ChangeSceneForMainMenu(){
		int c = SceneManager.GetActiveScene ().buildIndex;

		SceneManager.LoadScene (c + 1);
	}
	public void ChangeSceneFoBoss(){
		int c = SceneManager.GetActiveScene ().buildIndex;

		SceneManager.LoadScene (c - 1);
	}
}

