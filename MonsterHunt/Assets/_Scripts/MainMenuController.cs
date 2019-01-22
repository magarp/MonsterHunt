using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public AudioSource audio; 
	public GameObject mainMenuPannel;
	public GameObject rulesPannel;
	public GameObject scorepannel;
	public Text highScoreText;

	// Use this for initialization
	void Start () {
		int highscore;
		highscore = PlayerPrefs.GetInt(Globals.HIGH_SCORE_KEY, 0);
		UpdateUI(highscore);
	}

	public void ButtonHandlerPlay() {
	//	audio.Play();
		//SceneManager.LoadSceneAsync (1);
		StartCoroutine(playButtonAudioCR());
	}


	IEnumerator playButtonAudioCR(){
		audio.Play();
		yield return new WaitForSeconds(audio.clip.length);
		SceneManager.LoadSceneAsync (1);

	}

	public void Awake(){
		Cursor.lockState = CursorLockMode.None;		
		Cursor.visible = true;
	}

	public void quitButton(){
		Application.Quit ();

	}

	public void rulesButton(){
		mainMenuPannel.SetActive (false);
		scorepannel.SetActive (false);
		rulesPannel.SetActive (true);
	}
	public void scoreButton(){
		mainMenuPannel.SetActive (false);
		rulesPannel.SetActive (false);
		scorepannel.SetActive (true);

	}

	public void backButton(){
		mainMenuPannel.SetActive (true);
		rulesPannel.SetActive (false);
		scorepannel.SetActive (false);
	}

	public void UpdateUI(int score){

		if (score > 0) {
			highScoreText.text = "Highscore: " + score.ToString ();
		} else {
			highScoreText.text = "No Score!";
		}

	}

	public void ButtonHandlerReset(){
		PlayerPrefs.DeleteKey (Globals.HIGH_SCORE_KEY);
		UpdateUI (0);

	}
}

