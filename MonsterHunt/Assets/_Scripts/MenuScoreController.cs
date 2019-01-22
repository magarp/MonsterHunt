using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScoreController : MonoBehaviour {

	public Text highScoreText;

	// Use this for initialization
	void Start () {
		int highscore;
		highscore = PlayerPrefs.GetInt(Globals.HIGH_SCORE_KEY, 0);
		UpdateUI(highscore);
	}

	// Update is called once per frame
	void Update () {

	}

	public void ButtonHandlerReset(){
		PlayerPrefs.DeleteKey (Globals.HIGH_SCORE_KEY);
		UpdateUI (0);

	}

	public void UpdateUI(int score){

		if (score > 0) {
			highScoreText.text = "Highscore: " + score.ToString ();
		} else {
			highScoreText.text = "No Score!";
		}

	}
}