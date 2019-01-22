using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlueCharacterSelect : MonoBehaviour {

	public List<GameObject> models;
	private int selectionIndex = 0;
	private int BluePlayer;

	private void awake () 
	{
		PlayerPrefs.DeleteAll();
	}
	// Use this for initialization
	private void Start () {
		PlayerPrefs.DeleteAll();
		models = new List<GameObject> ();
		foreach (Transform t in transform) {
			models.Add(t.gameObject);
			t.gameObject.SetActive(false);
		}
		models [selectionIndex].SetActive (true);
	}

	
	// Update is called once per frame
	private void Update () {
	if (Input.GetKeyDown (KeyCode.D)) {
			Select (0);
			BluePlayer = 0;
			PlayerPrefs.SetInt ("BluePlayer", (BluePlayer));
		}
	else if (Input.GetKeyDown (KeyCode.A)) {
			Select (1);
			BluePlayer = 1;
			PlayerPrefs.SetInt ("BluePlayer", (BluePlayer));
		}
	}
	public void Select (int index)
	{
		if (index == selectionIndex)
			return;

		if (index < 0 || index >= models.Count)
			return;

		models [selectionIndex].SetActive (false);
		selectionIndex = index;
		models [selectionIndex].SetActive (true);
	}
}
