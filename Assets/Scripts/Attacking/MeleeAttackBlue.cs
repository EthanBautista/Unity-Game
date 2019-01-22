using UnityEngine;
using System.Collections;

public class MeleeAttackBlue : MonoBehaviour {
	
	public int m_PlayerNumber = 1;      // Used to identify which player belongs to which player. 
	
	public GameObject target;
	public ParticleSystem Slash;
	public float Cooldown;
	public int theDamage = 25;
	public BoxCollider trigger;
	
	private string m_AttackerName;
	private float CooldownTimer;
	private string Opponent;
	
	
	Animator anim;
	
	void Awake () {
		//		Slash = GetComponent <ParticleSystem> ();
		anim = GetComponent <Animator> ();
		//		trigger = GetComponent<BoxCollider>();
	}
	
	// Use this for initialization
	void Start () {
		m_AttackerName = "Fire" + m_PlayerNumber;
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CooldownTimer > 0) {
			CooldownTimer -= Time.deltaTime;
		}
		if (CooldownTimer < 0) {
			CooldownTimer = 0;
		}
		if (Input.GetButtonDown (m_AttackerName) && CooldownTimer == 0) {
			//		    Attack ();
			Slash.Play ();
			anim.SetBool ("IsShooting", true);
			trigger.enabled = true;
			
			
		} else {
			anim.SetBool ("IsShooting", false);
			
		}
		if (Input.GetButtonUp (m_AttackerName) ) {
			trigger.enabled = false;
		}
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Shootable1")
		{
			other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (theDamage);
			CooldownTimer = Cooldown;
		}
		
		
		if (CooldownTimer < Cooldown) {
			CooldownTimer += Time.deltaTime;
			
			//			ShieldIcon.fillAmount = CooldownTimer/Cooldown;
		}
		
	}
}
//		private void Attack () {


//		float distance = Vector3.Distance (target.transform.position, transform.position);
//
//		Vector3 dir = (target.transform.position - transform.position).normalized;
//
//		float direction = Vector3.Dot (dir, transform.forward);
//		CooldownTimer = Cooldown;
//
//
//		if (distance < 2.5f && distance > 1f) {
//
//			gameObject.SendMessage("TakeDamage", theDamage, SendMessageOptions.DontRequireReceiver);
//	
//
//
//		}
