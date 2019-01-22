using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthController : MonoBehaviour {

	public int health;
	public int maxHealth;
	private Image healthBar;
	private bool isdead = false;
	public GameObject sword;
	public TimeController timeController;


	void Start () {

		if (gameObject.tag == "Skeleton") {
			health = 4;
			maxHealth = 4;
		}

		if (gameObject.tag == "SkeletonBoss") {
			health = 20;
			maxHealth = 20;
		}
		healthBar = transform.Find("skeletonCanvas").Find("HealthBG").Find("Health").GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0 && isdead == true) {
			gameObject.GetComponent<AgentController>().dead();
			StartCoroutine(die());
			isdead = false;
		}
	}
	//increment the time by 10 when the skeleton dies
	IEnumerator die()
	{
		sword.GetComponent<BoxCollider> ().enabled = false;
		yield return new WaitForSeconds(3);
		timeController.incrementTime (20);
		Destroy (gameObject);
	}

	public void decrementHealth(){
		health = health - 1;
		healthBar.fillAmount = (float)health / (float)maxHealth;
		if (health == 0) {
			isdead = true;
		}

	}



}
