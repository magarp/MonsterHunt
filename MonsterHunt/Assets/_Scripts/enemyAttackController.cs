using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		
		if (other.tag == "Player") {
			GameObject go = GameObject.Find ("Player");
			PlayerHealthController healthController = (PlayerHealthController)go.GetComponent (typeof(PlayerHealthController));
			if (gameObject.tag == "GolemWeapon") {
				healthController.GolemHit ();
			} else if (gameObject.tag == "SkeletonWeapon") {
				healthController.SkeletonHit ();
			}else if (gameObject.tag == "SkeletonBossWeapon") {
				healthController.SkeletonBossHit ();
			}
		}
	}
}
