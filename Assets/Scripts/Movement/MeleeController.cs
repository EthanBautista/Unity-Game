using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MeleeController : MonoBehaviour {
	public int m_PlayerNumber = 1;      // Used to identify which player belongs to which player. 
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float strafeSpeed = 6;
	public float rotateVel = 100;
	public float distance =5f;
	//KeyCounts for double tapping
	public int KeyCount = 0;
	public Image ShieldIcon;
	public bool isDashing = false;
	public float dashDistance =20f;
	public float Cooldown = 5f;
	public bool isTapping = false;

	private float KeyTimer = 0f;
	private float CooldownTimer;
	//NAMES

	private string m_VerticalAxisName;
	private string m_RotateAxisName;
	private string m_DashAxisName;

	private string m_StrafeRight;
	private string m_StrafeLeft;

	//Values
	private float m_HorizontalInputValue;
	private float m_VerticalInputValue;
	private float m_RotateInputValue;
	private float StrafeRight;
	private float StrafeLeft;

	private float Timer;



	
	
	Animator anim;                      // Reference to the animator component.
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput, strafeInput;
	
	public Quaternion TargetRotation
	{
		get { return targetRotation;}
	}
	// Use this for initialization
	void Awake () 
	{
		anim = GetComponent <Animator> ();
	}
	void Start () {
	
		m_VerticalAxisName = "Vertical" + m_PlayerNumber;
		m_RotateAxisName = "Rotate" + m_PlayerNumber;
	
		m_StrafeRight = "StrafeRight" + m_PlayerNumber;
		m_StrafeLeft = "StrafeLeft" + m_PlayerNumber;
		targetRotation = transform.rotation;
		m_DashAxisName = "Dash" + m_PlayerNumber;
	
		rBody = GetComponent<Rigidbody> ();
	}
	void GetInput ()
	{
		
		forwardInput = Input.GetAxis (m_VerticalAxisName);
//		turnInput = Input.GetAxis (m_HorizontalAxisName);
		strafeInput = Input.GetAxis (m_RotateAxisName);
		StrafeRight = Input.GetAxis (m_StrafeRight);
		StrafeLeft = Input.GetAxis (m_StrafeLeft);
	}
	// Update is called once per frame
	void Update () {

		GetInput ();
		Turn();
	}
	
	
	void FixedUpdate ()
	{
		Run ();
		Animating ();
//		Shoot ();
		Strafe ();
		Dash ();
		
	}
	
	void Run ()
	{
		
		if (Mathf.Abs (forwardInput) > inputDelay) {
				//move
				rBody.velocity = transform.forward * forwardInput * forwardVel;		
		}
	}

	void Strafe ()
	{
		if (Mathf.Abs (StrafeRight) > inputDelay) {
			//Strafe
			//rBody.velocity = transform.TransformDirection(Vector3.right) *turnInput * strafeSpeed;
			transform.position = transform.position + transform.TransformDirection(Vector3.right) * distance * Time.deltaTime;
		} 
		if (Mathf.Abs (StrafeLeft) > inputDelay) {
			//Strafe
			//rBody.velocity = transform.TransformDirection(Vector3.right) *turnInput * strafeSpeed;
			transform.position = transform.position + transform.TransformDirection(Vector3.left) * distance * Time.deltaTime;
		} 


	}


	void Turn()
	{
		if (Mathf.Abs (strafeInput) > inputDelay) {
			targetRotation *= Quaternion.AngleAxis (rotateVel * strafeInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
	
	void Animating ()
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = forwardInput != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);

	}
//	void Shoot ()
//	{
//		if (Input.GetButtonDown (m_ShooterName)) {
//			anim.SetBool ("IsShooting", true);
//
//		} else {
//			anim.SetBool ("IsShooting", false);
//		}

	

	void Dash ()
	{
		if (CooldownTimer > 0) {
			CooldownTimer -= Time.deltaTime;
			KeyCount=0;
			Timer = Time.time * 0;
		}
		if (CooldownTimer < 0) {
			CooldownTimer = 0;
			KeyCount=0;
			
		}
		if (Input.GetButtonDown (m_DashAxisName)) {
			KeyCount = KeyCount + 1;
			Timer = Time.time * 0;
			
			if (KeyCount == 1 && Timer >0.5)
			{
				KeyCount=0;
				Timer -= Time.deltaTime;
			}
			if (KeyCount==2 && Timer > 0.5)
			{
				KeyCount=0;
			}
		}
		
		if (KeyCount == 2 && isDashing == false && CooldownTimer == 0 && Timer < 0.5) {
			KeyCount=0;
			isDashing = true;

		}
		if (isDashing)
		{
			transform.Translate(Vector3.forward * Time.deltaTime * dashDistance);
			KeyTimer++;
			anim.SetBool ("Dash", true);
			anim.SetBool ("IsWalking", false);
		} else {
			anim.SetBool ("Dash", false);


			//			StartCoroutine (Dashtime ());
		}
		if(KeyTimer> 15)
		{
			isDashing = false;
			KeyCount = 0;
			KeyTimer= 0;
			CooldownTimer = Cooldown;
		}
		if (KeyCount > 2) {
			KeyCount=0;
		}
		if (CooldownTimer < Cooldown) {
			//			CooldownTimer += Time.deltaTime;
			ShieldIcon.fillAmount = CooldownTimer/Cooldown;
		}
	}


}


