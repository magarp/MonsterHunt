﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startController : MonoBehaviour {

	public GameObject timer;
	public float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > 20) {
			timer.SetActive (true);
			Destroy (gameObject);
		}
		
	}
}
