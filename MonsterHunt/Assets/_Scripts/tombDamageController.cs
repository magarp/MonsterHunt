using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tombDamageController : MonoBehaviour {

	public int health;
	public int maxHealth;
	public Image healthBar;
	private bool isdead = false;
	public GameObject fire;
	public AudioSource audio;
	public AudioClip fireAudio;
	public winController winContro;

	void Start () {

		if (gameObject.tag == "gTomb") {
			health = 5;
			maxHealth = 5;
		}

		if (gameObject.tag == "sTomb") {
			health = 5;
			maxHealth = 5;
		}
	}

	// Update is called once per frame
	void Update () {
		if (health == 0 && isdead == true) {
			Destroy (healthBar);
			StartCoroutine(die());
			isdead = false;
		}
	}

	IEnumerator die()
	{
		fire.SetActive (true);
		audio.PlayOneShot (fireAudio);
		yield return new WaitForSeconds(fireAudio.length);
		Destroy (gameObject);
	}

	public void decrementHealth(){
		health = health - 1;
		healthBar.fillAmount = (float)health / (float)maxHealth;
		if (health == 0) {
			isdead = true;
			winContro.isDamaged(gameObject);
		}

	}



}
