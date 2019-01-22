using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBoxController : MonoBehaviour {

	public Transform healthBoxTransform;
	public GameObject healthBoxprefab;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("createHealthBox", 10.0f, 30.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void createHealthBox() {
		
		GameObject healthBox = Instantiate(healthBoxprefab, transform.position, transform.rotation) as GameObject;
	}
}
