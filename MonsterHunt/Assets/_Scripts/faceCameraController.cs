﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCameraController : MonoBehaviour {

	private Transform player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player").GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 direction = player.position - this.transform.position;
		direction.y = 0;
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
		Quaternion.LookRotation(direction), 0.1f);
	}
}
