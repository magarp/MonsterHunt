using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstAidController : MonoBehaviour {

	private PlayerHealthController playerhealthCont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other)
	{

		if (other.gameObject.name == "Player") {
			GameObject go = GameObject.Find ("Player");
			PlayerHealthController playerhealthCont = (PlayerHealthController)go.GetComponent (typeof(PlayerHealthController));
			playerhealthCont.increaseHealth ();
			Destroy (gameObject);

		}
	}
}
