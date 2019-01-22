using UnityEngine;
using System.Collections;

public class PrefabShooting : MonoBehaviour {
	
	public Rigidbody projectile;
	public int m_PlayerNumber = 1;      // Used to identify which player belongs to which player. 
	public float speed = 20;
	public Animator anim;                              // Reference to the animator.
	private string m_ShooterName;
	private bool m_ShooterValue;

	// Use this for initialization
	private void Start () {
		m_ShooterName = "Fire" + m_PlayerNumber;
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
		if (Input.GetButtonDown (m_ShooterName)){
			//cloning bullet
			Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation)as Rigidbody;
			//shooting bullet
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0,speed));
			//destory bullet
			Destroy (instantiatedProjectile.gameObject, 2);


	}

}
}

