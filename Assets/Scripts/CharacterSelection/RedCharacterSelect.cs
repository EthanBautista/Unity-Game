using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RedCharacterSelect : MonoBehaviour {
	
	public List<GameObject> models;
	private int selectionIndex = 0;
	private int RedPlayer;


	 void awake ()
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
	public void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.Keypad4)) {
			Select (1);
			RedPlayer = 1;
			PlayerPrefs.SetInt ("RedPlayer", (RedPlayer));
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow)||  Input.GetKeyDown (KeyCode.Keypad6)) {
				Select (0);
				RedPlayer = 0;
					PlayerPrefs.SetInt ("RedPlayer", (RedPlayer));
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
