using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemHealthController : MonoBehaviour {

	private int health;
	private int maxHealth;
	private Image healthBar;
	public TimeController timeController;

	void Start () {
		health = 4;
		maxHealth = 4;

		healthBar = transform.Find("golemCanvas").Find("HealthBG").Find("Health").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		if (health == 0) {
			gameObject.GetComponent<AgentController>().dead();
			StartCoroutine(die());
		}
	}

	//increment the time by 10 second when golem dies
	IEnumerator die()
	{
		yield return new WaitForSeconds(3);
		timeController.incrementTime (20);
		Destroy (gameObject);
	}

	public void decrementHealth(){
		health = health - 1;
		healthBar.fillAmount = (float)health / (float)maxHealth;

	}



}
