using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int m_PlayerNumber = 2;      // Used to identify which player belongs to which player. 
	public float speed = 6f;            // The speed that the player will move at.
	private string m_HorizontalAxisName;
	private string m_VerticalAxisName;
	private string m_RotateAxisName;
	private float m_HorizontalInputValue;
	private float m_VerticalInputValue;
	private float m_RotateInputValue;
	private Transform m_Transform;
	private string m_ShooterName;


	Vector3 movement;                   // The vector to store the direction of the player's movement.
	Animator anim;                      // Reference to the animator component.
	Rigidbody playerRigidbody;          // Reference to the player's rigidbody.


	
	private void Awake ()
	{
		
		// Set up references.
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent <Rigidbody> ();

	}
	private void Start ()
	{
		m_HorizontalAxisName = "Horizontal" + m_PlayerNumber;
		m_VerticalAxisName = "Vertical" + m_PlayerNumber;
		m_RotateAxisName = "Rotate" + m_PlayerNumber;
		m_ShooterName = "Fire" + m_PlayerNumber;

	}
	private void Update ()
	{
		// Store the input axes.
		m_HorizontalInputValue = Input.GetAxisRaw (m_HorizontalAxisName);
		m_VerticalInputValue = Input.GetAxisRaw (m_VerticalAxisName);

		
		
		if (Input.GetButtonDown (m_ShooterName)) {
			anim.SetBool ("IsShooting", true);
		} else {
			anim.SetBool ("IsShooting", false);
		}
		
	}
	private void FixedUpdate ()
	{
		// Move the player around the scene.
		Move ();

		Turning ();
		// Animate the player.
		Animating ();

	}

	
	private void Move ()
	{
//		{
//			if (Input.GetButtonDown (m_HorizontalAxisName)) {
//				Vector3 movement = new Vector3 (m_HorizontalInputValue, m_VerticalInputValue) * speed * Time.deltaTime;
//				playerRigidbody.MovePosition (transform.position + movement);			
//			}
//		 Set the movement vector based on the axis input.
		movement.Set (m_HorizontalInputValue, 0f, m_VerticalInputValue);


	//	Normalise the movement vector and make it proportional to the speed per second.
		movement = movement.normalized * speed * Time.deltaTime;
	// Move the player to it's current position plus the movement.
		playerRigidbody.MovePosition (transform.position + movement);
	
		}

	private void Turning ()
	{
		transform.Rotate(0,Input.GetAxis(m_RotateAxisName)*60*Time.deltaTime,0);

	}

	private void Animating ()
	{
		// Create a boolean that is true if either of the input axes is non-zero.
		bool walking = m_VerticalInputValue != 0f;
		
		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}

}