using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class objectiveManger : MonoBehaviour {
	public Text gate;
	public Text skeltonboss;
	public Text tomb;
	public List<GameObject> skeletonBossList;
	public List<GameObject> tombList;

	private bool isOpenedOnce;




	// Use this for initialization
	void Start () {
		gate.text = "Gate : Locked";
		skeltonboss.text = "Skeleton Boss:" + skeletonBossList.Count;
		tomb.text = "Tomb:" + tombList.Count;
		isOpenedOnce = false;

			
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("SkeletonBoss") == null && isOpenedOnce == false) {
			gate.text = "Gate : Unlocked";
			isOpenedOnce = false;
		}

		updateSkeltonBossList ();
		updateTombList ();
	}

	void updateSkeltonBossList(){
		for(int i = 0; i < skeletonBossList.Count; i++)
		{
			if (skeletonBossList [i] == null) {
				skeletonBossList.RemoveAt (i);
			}	
		}
		skeltonboss.text = "Skeleton Boss:" + skeletonBossList.Count;

	}

	void updateTombList(){
		for(int i = 0; i < tombList.Count; i++)
		{
			if (tombList [i] == null) {
				tombList.RemoveAt (i);
			}	
		}
		tomb.text = "Tomb:" + tombList.Count;

	}

}
