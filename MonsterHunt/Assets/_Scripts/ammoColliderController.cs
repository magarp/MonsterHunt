using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoColliderController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider other) {


		if (other.gameObject.name == "Player") {

			GameObject go = GameObject.Find ("Weapons");
			weaponController weaponCont = (weaponController)go.GetComponent (typeof(weaponController));
			weaponCont.incrementAmmo ();
			Destroy (gameObject);


		}

		if (other.gameObject.name == "drop") {
			
			Rigidbody rb = GetComponent<Rigidbody>();
			rb.useGravity = false;
			rb.isKinematic = true;

		}

	}
}
