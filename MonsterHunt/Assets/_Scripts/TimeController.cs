using UnityEngine;
using System.Collections; 
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour {

	public AudioSource audio;
	public float timeRemaining;
	public Text timeText; 
	public AudioClip timerAudio;
	public AudioClip endAudio;
	public bool hasEndAudioPlayed = false;
	public GameObject poison;
	public PlayerHealthController playerHealth;
	public float score; 
	public GameObject poisonCanvas;

	void Start () {
		score = 320;
		timeRemaining = 150;
		InvokeRepeating ("PlayTimer", 0.0f, 1.00f);

	}

	void PlayTimer(){
		audio.PlayOneShot (timerAudio);

	}


	void Update () {
		score -= Time.deltaTime;
		if (score < 0) {
			score = 0;
		}

		if (timeRemaining >= 0) {
			timeRemaining = timeRemaining -= Time.deltaTime; 
			timeText.text = "Time Left:" + Mathf.Round(timeRemaining);

		}
			
		else 
		{
			if (hasEndAudioPlayed == false) {
				poisonCanvas.SetActive (true);
				StartCoroutine (LateCall ());
				hasEndAudioPlayed = true;
				poison.SetActive (true);
				playerHealth.activatePoison ();
				Destroy (poisonCanvas, 7);
			}

		}
	}
		

	IEnumerator LateCall(){
		audio.PlayOneShot (endAudio);
		yield return new WaitForSeconds(3);

	}

	public void incrementTime(int seconds){
		timeRemaining = timeRemaining + seconds;
	}
}
