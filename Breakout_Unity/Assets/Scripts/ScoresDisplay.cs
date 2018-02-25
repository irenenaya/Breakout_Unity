using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresDisplay : MonoBehaviour {

	public GameObject canvas;
	public GameObject parent;
	HighScoreHandler handler;
	// Use this for initialization
	void Start () {
		handler = GameObject.FindGameObjectWithTag ("GameController").GetComponent<HighScoreHandler> ();
		int size = handler.DisplayData.Length;
		for (int i = 0; i < size; ++i) {
			GameObject temp = Instantiate (canvas);
			temp.transform.SetParent (parent.transform, false);
			temp.transform.GetChild (0).gameObject.GetComponent<Text> ().text = (i +1) + ".";
			temp.transform.GetChild (1).gameObject.GetComponent<Text> ().text = handler.DisplayData [i].name;
			temp.transform.GetChild (2).gameObject.GetComponent<Text> ().text = (handler.DisplayData [i].score).ToString();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
