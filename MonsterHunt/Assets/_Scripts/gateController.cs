using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateController : MonoBehaviour {
	// Use this for initialization

	private bool isOpenedOnce;
	public GameObject message;
	public CutsceneController cutScene;
	public GameObject mainCamaera;

	void Start () {
		isOpenedOnce = false;
	}

	// Update is called once per frame
	void Update () {

		if (GameObject.FindGameObjectWithTag ("SkeletonBoss") == null && isOpenedOnce == false) {
			cutScene.startCutsScene ();
			mainCamaera.SetActive (false);
			isOpenedOnce = true;
			StartCoroutine (CutsceneInterval ());
		}
	}

	IEnumerator CutsceneInterval ()
	{
		yield return new WaitForSeconds (14);
	}


	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			message.SetActive (true);

		}

	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") {
			message.SetActive (false);

		}
	}
}
