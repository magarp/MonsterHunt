using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectiveController : MonoBehaviour {

	public GameObject objective;


	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Tab))
			objective.SetActive (true);

		if (Input.GetKeyUp(KeyCode.Tab))
			objective.SetActive (false);
	}
}
