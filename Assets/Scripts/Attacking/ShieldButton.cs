using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour {
	
	public Rigidbody projectile;
	public int m_PlayerNumber = 1;      // Used to identify which player belongs to which player. 
	public float Cooldown = 20f;
	private float CooldownTimer;
	private string m_ShooterName;
	private bool m_ShooterValue;
	public Image ShieldIcon;
//	private bool CanSpawn = true;


	
	// Use this for initialization
	private void Start () {
		m_ShooterName = "Shield" + m_PlayerNumber;
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}
	
	private void FixedUpdate ()
	{
		Shoot ();
	}
	private void Shoot ()
	{
		if (CooldownTimer > 0) {
			CooldownTimer -= Time.deltaTime;
		}
		if (CooldownTimer < 0) {
			CooldownTimer = 0;
		}
//		if (Input.GetButtonDown (m_ShooterName) && CanSpawn == true && CooldownTimer == 0)
		if (Input.GetButtonDown (m_ShooterName) && CooldownTimer == 0) {
			//cloning shield
			Rigidbody instantiatedProjectile = Instantiate (projectile, transform.position, transform.rotation)as Rigidbody;
			//destory shield
			Destroy (instantiatedProjectile.gameObject, 8);
//			CanSpawn = false;
			CooldownTimer = Cooldown;


			}
		if (CooldownTimer < Cooldown) {
//			CooldownTimer += Time.deltaTime;
			ShieldIcon.fillAmount = CooldownTimer/Cooldown;
		}

	
		}



}




