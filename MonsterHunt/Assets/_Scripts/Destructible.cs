using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
	
	public GameObject destroyedVersion;

	public void destroy (){

		GameObject destroyedVersionGO = Instantiate(destroyedVersion, transform.position, transform.rotation);
		Destroy(gameObject);
		Destroy (destroyedVersionGO, 15f);

	}

}
