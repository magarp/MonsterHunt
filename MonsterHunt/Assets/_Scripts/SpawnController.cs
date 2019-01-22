using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

	public GameObject enemyPrefab;
	private int counter;
	public GameObject parentGameObject;

	// Use this for initialization
	void Start () {
		counter = 0;
		InvokeRepeating ("spawnEnemy", 1, 15);

	}

	void Update(){

		if (counter == 50 ){
			CancelInvoke ();
		}
	}

	void spawnEnemy(){
		(Instantiate (enemyPrefab, transform.position, transform.rotation) as GameObject).transform.parent = parentGameObject.transform;
		counter++;
	
	}





}