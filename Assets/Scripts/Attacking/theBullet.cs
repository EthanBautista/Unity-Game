using UnityEngine;
using System.Collections;

public class theBullet : MonoBehaviour {

	public int Damage = 10;  




	private void Start () {
	
	
	}
	
	// Update is called once per frame
	private void Update () {

	}
private void Awake ()
{
	
}

private void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "Shootable2")
		{
			other.gameObject.GetComponent<PlayerHealth> ().TakeDamage (Damage);
	
	} else {
		
	}
	}

}


