using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeColliderController : MonoBehaviour {

	public GameObject ammoBoxPrefab;
	public AudioSource ammoDropped;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "plane") {
			GameObject ammoBox = Instantiate(ammoBoxPrefab, transform.position, transform.rotation) as GameObject;
			ammoDropped.Play ();
		}
}
}
