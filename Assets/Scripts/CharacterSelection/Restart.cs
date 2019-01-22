using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		Application.LoadLevel(0);
	}
}
