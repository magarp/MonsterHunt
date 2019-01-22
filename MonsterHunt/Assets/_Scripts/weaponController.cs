using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class weaponController : MonoBehaviour {

	public Image crosshairDefault;
	public Image crosshairSelected;
	public Camera fpsCamera; 
	public float range = 100f;
	public ParticleSystem gunMuzzleflash;
	public GameObject impactParticleEffect;
	public List<GameObject> DestructibleObjectlist = new List<GameObject>();
	public GameObject[] weapon;
	private int weaponKey;
	public int[] weaponAmmo;
	public Text ammoText;

	public AudioSource audio;
 	public AudioClip weaponHeavy;
	public AudioClip weaponAk;
	public AudioClip weaponPistol;
	public AudioClip weaponChange;
	public AudioClip emptyAmmo;
	public AudioClip reloadAudio;
	public bool hasEndAudioPlayed = false;
	public tombDamageController gtombDmgController;
	public tombDamageController stombDmgController;




	// Use this for initialization
	void Start () {
		
	}

	void Awake(){

		ToggleSelectedCursor(false);
		weapon [0].SetActive (true);
		weapon [1].SetActive (false);
		weapon [2].SetActive (false);
		weaponKey = 0;
		weaponAmmo = new int[3];

		weaponAmmo [0] = 40;
		weaponAmmo [1] = 40;
		weaponAmmo [2] = 40;
		ammoText.text = 40.ToString ();

	}


	
	// Update is called once per frame
	void Update () {
		fire ();
		changeWeapon ();

			
	}
		

	public void fire(){

		if (Input.GetButtonDown ("Fire1")) {


			// only fire if the ammo not equall to null 
			if (weaponAmmo[weaponKey] != 0 ) {
				weaponAmmo [weaponKey] = weaponAmmo [weaponKey] - 1;
				ammoText.text = "" + weaponAmmo[weaponKey].ToString ();

				playWeaponAudio ();
				RaycastHit hit;
		
				if (Physics.Raycast (fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range)) {

					if (hit.transform.tag == "Skeleton" || hit.transform.tag == "SkeletonBoss") {
						GameObject skeletongo = hit.transform.gameObject;
						AgentController skeletonController = (AgentController)skeletongo.GetComponent (typeof(AgentController));
						skeletonController.takeDamage ();

						StartCoroutine (setTakingDamage (skeletonController));
						SkeletonHealthController skeletonHealthController = (SkeletonHealthController)skeletongo.GetComponent (typeof(SkeletonHealthController));
						skeletonHealthController.decrementHealth ();

					} else if (hit.transform.tag == "Golem") {
						GameObject golemgo = hit.transform.gameObject;
						AgentController golemController = (AgentController)golemgo.GetComponent (typeof(AgentController));
						golemController.takeDamage ();
						StartCoroutine (setTakingDamage (golemController));
						GolemHealthController golemHealthController = (GolemHealthController)golemgo.GetComponent (typeof(GolemHealthController));
						golemHealthController.decrementHealth ();

					} else if (hit.transform.tag == "gTomb" ) {
						gtombDmgController.decrementHealth ();
					}else if (hit.transform.tag == "sTomb" ) {
						stombDmgController.decrementHealth ();
					}



					// loop through the destructibleObjectlist while firing bullet and destruct the object when in contact with ray hit. 
					for (int i = 0; i < DestructibleObjectlist.Count; i++) {
					
						if (hit.transform.name == DestructibleObjectlist [i].name) {
							GameObject destructibleGameObject = GameObject.Find (hit.transform.name);
							Destructible destructible = (Destructible)destructibleGameObject.GetComponent (typeof(Destructible));
							destructible.destroy ();
							DestructibleObjectlist.RemoveAt (i);
						}	
					}
						
					if (hit.rigidbody) {
						hit.rigidbody.AddForceAtPosition (10000f * fpsCamera.transform.forward, hit.point);
					}
					ToggleSelectedCursor (true);
					GameObject impactEffect = Instantiate (impactParticleEffect, hit.point, Quaternion.LookRotation (hit.normal));
					Destroy (impactEffect, 2f);

				} 
				gunMuzzleflash.Play ();


			} else {
				audio.PlayOneShot (emptyAmmo);

			}
				
		} else {
			ToggleSelectedCursor (false);

		}
	}

	void noAmmoAudio(){
		audio.PlayOneShot (emptyAmmo);

	
	}
				

	// Playe weapon audio when fired
	void playWeaponAudio(){

		if (weaponKey == 0) {
			audio.PlayOneShot (weaponHeavy);

		}else if(weaponKey == 1){

			audio.PlayOneShot (weaponAk);

		}else if(weaponKey == 2){

			audio.PlayOneShot (weaponPistol);
		}
	}

	// change Weapon when alpha1,2 or 3 is pressed and update weaponkey
	public void changeWeapon(){

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			weaponKey = 0;
			weapon [0].SetActive (true);
			weapon [1].SetActive (false);
			weapon [2].SetActive (false);
			ammoText.text = "" + weaponAmmo[weaponKey].ToString ();

			audio.PlayOneShot (weaponChange);


		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			weaponKey = 1;
			weapon [0].SetActive (false);
			weapon [1].SetActive (true);
			weapon [2].SetActive (false);
			ammoText.text = "" + weaponAmmo[weaponKey].ToString ();

			audio.PlayOneShot (weaponChange);



		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			weaponKey = 2;
			weapon [0].SetActive (false);
			weapon [1].SetActive (false);
			weapon [2].SetActive (true);
			ammoText.text = "" + weaponAmmo[weaponKey].ToString ();

			audio.PlayOneShot (weaponChange);

		} else {

		}

	}

	// change default crosshair to selected when shooting
	void ToggleSelectedCursor(bool showSelectedCursor) {
		if(showSelectedCursor == true) {
			crosshairDefault.GetComponent<Image>().enabled = false;
			crosshairSelected.GetComponent<Image>().enabled = true;
		} else {
			crosshairDefault.GetComponent<Image>().enabled = true;
			crosshairSelected.GetComponent<Image>().enabled = false;
		}
	}

	public void incrementAmmo(){
		weaponAmmo [0] = weaponAmmo [0] + 10;
		weaponAmmo [1] = weaponAmmo [1] + 10;
		weaponAmmo [2] = weaponAmmo [2] + 10;
		ammoText.text = "" + weaponAmmo [weaponKey].ToString ();
		audio.PlayOneShot (reloadAudio);

	}

	IEnumerator setTakingDamage(AgentController agentCont){
		yield return new WaitForSeconds(0.5f); 
		agentCont.isTakingDamage = false; 

	}

}
