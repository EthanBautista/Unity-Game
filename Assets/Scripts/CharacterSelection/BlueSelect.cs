using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlueSelect : MonoBehaviour {
	
	public List<GameObject> models;
	private int selectionIndex = 0;
	private int savedplayer = 0;
	
	
	
	
	void Awake () {
		//		savedplayer = PlayerPrefs.GetInt ("Redplayer");
		savedplayer = PlayerPrefs.GetInt ("BluePlayer");
		
		
	}
	// Use this for initialization
	private void Start () {
		models = new List<GameObject> ();
		foreach (Transform t in transform) {
			models.Add(t.gameObject);
			t.gameObject.SetActive(false);
		}
		models [selectionIndex].SetActive (true);
		if (savedplayer == 0) {
			Select (0);
		}
		//
		else if (savedplayer == 1) {
			Select (1);
		}
	}
	
	
	// Update is called once per frame
	private void Update () {
		
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
