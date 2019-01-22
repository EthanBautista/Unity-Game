using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeleeHealth : MonoBehaviour
{	
	public int m_PlayerNumber = 1;     						    // Used to identify which player belongs to which player. 
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
	public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
	
	
	Animator anim;                                              // Reference to the Animator component.
	AudioSource playerAudio;                                    // Reference to the AudioSource component.
	PlayerController playerMovement;                              // Reference to the player's movement.
	MeleeController meleeMovement; 
	MeleeAttack meleeAttack;
	MeleeAttackBlue meleeAttackBlue;
	theBullet theBullet;
	
	bool isDead;                                                // Whether the player is dead.
	bool damaged;                                               // True when the player gets damaged.
	
	
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent <Animator> ();
	
		meleeMovement = GetComponentInParent <MeleeController> ();
		meleeAttack = GetComponentInParent <MeleeAttack> ();
		meleeAttackBlue = GetComponentInChildren <MeleeAttackBlue> ();
		
		
		// Set the initial health of the player.
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColour;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		
		// Reset the damaged flag.
		damaged = false;
	}
	
	
	public void TakeDamage (int Damage)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;
		
		// Reduce the current health by the damage amount.
		currentHealth -= Damage;
		
		// Set the health bar's value to the current health.
		healthSlider.value = currentHealth;
		
		
		
		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
			
		}
	}
	
	
	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;
		anim.SetTrigger ("Die");
	
		meleeMovement.enabled = false;
		meleeAttack.enabled = false;
		meleeAttackBlue.enabled = false;
	}
	
	// Tell the animator that the player is dead.
	
	
	
	// Turn off the movement and shooting scripts.
	
}  
