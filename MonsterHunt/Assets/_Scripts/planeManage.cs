using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeManage : MonoBehaviour {

	public GameObject planePrefab;
	public Transform origin;
	// Use this for initialization
	void Start () {
		Transform planeTransform = GetComponent<Transform> ();
		InvokeRepeating("createPlane", 10.0f, 30.0f);

	}
	
	// Update is called once per frame
	void Update () {

	}

	void createPlane(){
		
		GameObject ammoPlane = Instantiate(planePrefab, origin.position, origin.rotation) as GameObject;
		Destroy (ammoPlane, 25);

	}
}
