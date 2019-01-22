using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

	public enum AgentType 
	{
		Patrolling = 0,
		Chasing,
		idle
	}

	public AgentType type;
	public Transform[] waypoints;
	public AudioSource audio;
	public AudioClip pain1;
	public AudioClip pain2;
	public AudioClip deadAudio;

	private Transform player;
	private Animator AgentAnim;
	private int waypointID;
	private int painNum = 1;
	private bool isdead = false; 
	private Vector3 direction;
	private float angleToTarget;
	public bool isTakingDamage;
	public GameObject invisibleParticles;
	private PlayerHealthController playerHealth;


	// Use this for initialization
	void Start () 
	{
		waypointID = Random.Range (0, waypoints.Length);
		type = AgentType.Patrolling;
		AgentAnim = GetComponent<Animator>();
		isTakingDamage = false;
		player = GameObject.FindWithTag ("Player").GetComponent<Transform> ();
		playerHealth = GameObject.FindWithTag ("Player").GetComponent<PlayerHealthController> ();
	}

	// Update is called once per frame
	void Update () 
	{


		direction = player.position - this.transform.position;
		angleToTarget = Vector3.Angle (direction, this.transform.forward);

		if (type == AgentType.Patrolling && isdead == false) {

			Vector3 waypointDirection = waypoints [waypointID].position - this.transform.position;

			this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
				Quaternion.LookRotation (waypointDirection), 0.1f);
			
			this.transform.Translate (0, 0, 0.14f);
			AgentAnim.SetBool ("isIdle", false);
			AgentAnim.SetBool ("isWalking", true);
			AgentAnim.SetBool ("isAttacking", false);
			AgentAnim.SetBool ("isDamaged", false);

			float distance = Vector3.Distance (waypoints [waypointID].transform.position, this.transform.position);
			if (distance < 3f) {
				waypointID = Random.Range (0, waypoints.Length);
			}

			if (Vector3.Distance (player.position, this.transform.position) < 10 && angleToTarget < 90 && playerHealth.health > 0 ) {
				type = AgentType.Chasing;
				}

		}
		if (type == AgentType.Chasing && isdead == false){
			if (Vector3.Distance (player.position, this.transform.position) < 10 && angleToTarget < 90 && playerHealth.health > 0) {
				
				direction.y = 0;

				this.transform.rotation = Quaternion.Slerp (this.transform.rotation,
					Quaternion.LookRotation (direction), 0.1f);

				AgentAnim.SetBool ("isIdle", false);
				AgentAnim.SetBool ("isDamaged", false);
				AgentAnim.SetBool ("isAttacking", false);

				if (isTakingDamage == false && gameObject.tag == "Skeleton" || gameObject.tag == "Golem") {
					if (direction.magnitude > 2.5) {
						this.transform.Translate (0, 0, 0.11f);
						AgentAnim.SetBool ("isWalking", true);
						AgentAnim.SetBool ("isAttacking", false);
						AgentAnim.SetBool ("isDamaged", false);

					} else {
						AgentAnim.SetBool ("isAttacking", true);
						AgentAnim.SetBool ("isWalking", false);
						AgentAnim.SetBool ("isDamaged", false);

					}
				}else if (isTakingDamage == false && gameObject.tag == "SkeletonBoss" ) {


					if (direction.magnitude > 3.5) {
						this.transform.Translate (0, 0, 0.11f);
						AgentAnim.SetBool ("isWalking", true);
						AgentAnim.SetBool ("isAttacking", false);
						AgentAnim.SetBool ("isDamaged", false);

					} else {
						AgentAnim.SetBool ("isAttacking", true);
						AgentAnim.SetBool ("isWalking", false);
						AgentAnim.SetBool ("isDamaged", false);

					}
				}
			} else {
				type = AgentType.Patrolling;
			}
		}
}

	public void dead(){

		isdead = true; 
		audio.PlayOneShot (deadAudio);
		AgentAnim.SetBool("isIdle", false);
		AgentAnim.SetBool("isWalking", false);
		AgentAnim.SetBool("isAttacking", false);
		AgentAnim.SetBool("isDamaged", false);
		AgentAnim.SetBool("isDead", true);
	}

	public void takeDamage(){

		if (isdead == false) {
			isTakingDamage = true;
			AgentAnim.SetBool ("isIdle", false);
			AgentAnim.SetBool ("isWalking", false);
			AgentAnim.SetBool ("isAttacking", false);
			AgentAnim.SetBool ("isDamaged", true);

			if (painNum == 1) {
				audio.PlayOneShot (pain1);
				painNum = 2;
			} else if (painNum == 2) {
				audio.PlayOneShot (pain2);
				painNum = 1;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "walls") {
			invisibleParticles.SetActive (true);
		}
	} 

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "walls") {
			invisibleParticles.SetActive (false);
		}	
	}



}

