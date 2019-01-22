using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public int m_PlayerNumber = 1;      // Used to identify which player belongs to which player. 
	public float inputDelay = 0.1f;
	public float forwardVel = 12;
	public float strafeSpeed = 6;
	public float rotateVel = 100;
	public float distance =5f;

	private string m_VerticalAxisName;
	private string m_RotateAxisName;
	private float m_HorizontalInputValue;
	private float m_VerticalInputValue;
	private float m_RotateInputValue;
	private string m_ShooterName;
	private string m_StrafeRight;
	private string m_StrafeLeft;
	private float StrafeRight;
	private float StrafeLeft;



	Animator anim;                      // Reference to the animator component.
	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, strafeInput;

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
		m_ShooterName = "Fire" + m_PlayerNumber;
		m_StrafeRight = "StrafeRight" + m_PlayerNumber;
		m_StrafeLeft = "StrafeLeft" + m_PlayerNumber;
		targetRotation = transform.rotation;
		rBody = GetComponent<Rigidbody> ();
	}
	void GetInput ()
	{
	
		forwardInput = Input.GetAxis (m_VerticalAxisName);

		strafeInput = Input.GetAxis (m_RotateAxisName);
		StrafeRight = Input.GetAxis (m_StrafeRight);
		StrafeLeft = Input.GetAxis (m_StrafeLeft);
	}
	// Update is called once per frame
	void Update () {
//		if (Input.anyKeyDown){
//			if (Keynumber == 1 && KeyTimer > 0) {
//			}else{
//					Keynumber += 1;
//					KeyTimer = 0.5f;
//				}
//				if (KeyTimer > 0) {
//					KeyTimer -= 1 * Time.deltaTime;
//				} else {
//					Keynumber = 0;
//				}



		GetInput ();
		Turn();
			}


	void FixedUpdate ()
	{
		Run ();
		Animating ();
		Shoot ();
		Strafe ();


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
	void Shoot ()
	{
		if (Input.GetButtonDown (m_ShooterName)) {
			anim.SetBool ("IsShooting", true);
		} else {
			anim.SetBool ("IsShooting", false);
		}
	}

	}
