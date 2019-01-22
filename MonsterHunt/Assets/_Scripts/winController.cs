using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class winController : MonoBehaviour {

	public GameObject victoryCanvas;
	public GameObject gameCanvas;
	public bool sTombTriggeredOnce;
	public bool gTombTriggeredOnce;
	public GameObject enemies;
	public GameObject timer;
	public Text scoreText;
	public TimeController timecontroller;

	void Start () {
		Cursor.visible = true;
		Cursor.lockState =  CursorLockMode.None;
		sTombTriggeredOnce = false;
		gTombTriggeredOnce = false;

	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("sTomb") == null && GameObject.FindGameObjectWithTag ("gTomb") == null) {

			if (sTombTriggeredOnce == true && gTombTriggeredOnce ==  true) {
				gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ().mouseLook.lockCursor = false;
				victoryCanvas.SetActive (true);
				gameCanvas.SetActive (false);
				sTombTriggeredOnce = false;
				gTombTriggeredOnce = false;
				enemies.SetActive (false);
				timer.SetActive (false);
				int score = Mathf.RoundToInt (timecontroller.score);
				scoreText.text = "Score : " + score;

				int highscore;
				highscore = PlayerPrefs.GetInt(Globals.HIGH_SCORE_KEY, 0);
				if (timecontroller.score > highscore) {
					PlayerPrefs.SetInt(Globals.HIGH_SCORE_KEY, score);
				}

			}
		}
	}
		

	public void playAgain() {
		SceneManager.LoadSceneAsync (1);

	}


	public void mainMenu(){
		SceneManager.LoadSceneAsync (0);
	}

	public void isDamaged(GameObject tombGameobject){

		if (tombGameobject.tag == "gTomb") {
			sTombTriggeredOnce = true;
		}
		
		else if (tombGameobject.tag == "sTomb") {
			gTombTriggeredOnce = true;
		}
	}

}
