	using System.Collections;
	using UnityEngine;
	using System.Collections;
	using DG.Tweening;
	using UnityEngine.UI;

	public class CutsceneController : MonoBehaviour {

	public GameObject imageGO;
	private Image imageToFade;
	public Transform cameraEndPosition;
	public Transform cam;
	public Transform gate;
	public Transform gateEndPosition;
	public AudioSource doorAudio;
	public GameObject mainCamera;
	public GameObject miniMapCamera;
	public GameObject gameCanvas;
	public GameObject stopEnemies; 


		public void startCutsScene(){
			stopEnemies.SetActive (false);
			miniMapCamera.SetActive (false);
			gameCanvas.SetActive (false);

			imageGO.SetActive (true);
			imageToFade = imageGO.GetComponent<Image> ();
			StartCoroutine (Cutscene ());

		}

		IEnumerator Cutscene ()
		{
			yield return new WaitForSeconds (1);
			imageToFade.DOFade (0, 2);
			cam.DOMove (cameraEndPosition.position, 6);
			yield return new WaitForSeconds (5);
			gate.DOMove (gateEndPosition.position, 9);
			doorAudio.Play ();
			yield return new WaitForSeconds (8);
			imageToFade.DOFade (1, 2);
			yield return new WaitForSeconds (2);

			imageGO.SetActive (false);
			mainCamera.SetActive (true);
			stopEnemies.SetActive (true);
			miniMapCamera.SetActive (true);
			gameCanvas.SetActive (true);
		}
	}
