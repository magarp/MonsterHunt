using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterController : MonoBehaviour {

	private string allMissiontext;
	public GameObject missiontextGameobject;
	public Text missionText;
	private string text = "";

	// Use this for initialization
	void Start () {
		allMissiontext = "\n              " +
			"WELCOME TO THE MONSTER HUNT\n\n " +
			"The area has been occupied by the monsters.\n" +
			"1. Destory the gaint Skeletons\n" +
			"2. Unlock the door and destory thier tomb\n" +
			"3. Complete the mission before the time limit\n" +
			"I will supply the ammo through the aircraft\n" +
			"It will be located on the middle of warzone\n" +
			"Hint: Time limit will be extended per enemy killed\n"+
			"Press “KEY-CODE = TAB” to view the Mission Objectives. \n";
		StartCoroutine (printText ());
	}

	IEnumerator printText(){
		for(int i = 0; i < allMissiontext.Length; i++){
			text = allMissiontext.Substring(0,i);
			missionText.text = text;
			yield return new WaitForSeconds(0.03f);
		}
		yield return new WaitForSeconds (3);
		missiontextGameobject.SetActive (false);
	}

}
