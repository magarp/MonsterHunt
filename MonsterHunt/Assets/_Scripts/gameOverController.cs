using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.visible = true;
		Cursor.lockState =  CursorLockMode.None;
	}


	public void retryButton() {
		SceneManager.LoadSceneAsync (1);

	}
		

	public void mainMenu(){
		SceneManager.LoadSceneAsync (0);
	}


}
