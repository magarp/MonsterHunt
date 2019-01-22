using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour {
	public AudioSource audio;
	public AudioClip pain1;
	public AudioClip pain2;
	public AudioClip pain3;
	private int painNum = 1;
	public Text healthText;
	public int health;
	public GameObject pannel;
	public GameObject playerCanvas;
	public GameObject gameOverCanvas;
	private bool poisoned;
	public GameObject weapon;
	public GameObject timer;


	// Use this for initialization
	void Start () {
		health = 40;
		healthText.text = health.ToString ();
	}

	void Update(){

		if (health == 0) {
			gameOverCanvas.SetActive (true);
			gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController> ().mouseLook.lockCursor = false;
			weapon.SetActive (false);
			playerCanvas.SetActive (false);
			CancelInvoke();
			Destroy (timer);
		}
	}

	void isPoisoned(){

		if (health == 1) {
			decrementHealth (1);
		} else {
			decrementHealth (2);
		}
		painNoise ();
		StartCoroutine(damagePannel());

	}


	public void SkeletonHit(){

		decrementHealth (1);
		painNoise ();
		StartCoroutine(damagePannel());

	}

	public void SkeletonBossHit(){
		if (health == 1) {
			decrementHealth (1);
		}
		else{
			decrementHealth (2);
		} 
		painNoise ();
		StartCoroutine(damagePannel());

	}

	public void increaseHealth(){
		health = health + 10;
		healthText.text = health.ToString ();

	}

	public void GolemHit(){

		decrementHealth (1);
		painNoise ();
		StartCoroutine(damagePannel());

	}

	public void activatePoison(){
		InvokeRepeating ("isPoisoned", 2, 2);

	}

	public void deactivePoison(){
		CancelInvoke ("isPoisoned");
	}


	void decrementHealth(int num){
	
		if (health >= 1) {
			health = health - num; 
			healthText.text = health.ToString ();
		} 

	}

	IEnumerator damagePannel()
	{
		pannel.SetActive (true);
		yield return new WaitForSeconds(1);
		pannel.SetActive (false);
	}
		
	void painNoise(){
		
		if (painNum == 1) {
			audio.PlayOneShot (pain1);
			painNum = 2;
		}else if (painNum == 2) {
			audio.PlayOneShot (pain2);
			painNum = 3;
		}else if (painNum == 3) {
			audio.PlayOneShot (pain3);
			painNum = 1;
		}
	}





}
