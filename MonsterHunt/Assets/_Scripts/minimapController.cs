using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimapController : MonoBehaviour {

	public PlayerHealthController playerHealth;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.health <= 0) {
			gameObject.SetActive (false);
		}
	}
}
