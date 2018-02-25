using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {
	Text text;
	// Use this for initialization
	void Start () {
		

	}
	// Can't use Start because the object exists always, gets activated and deactivated. 
	void OnEnable() {
		text = GetComponent<Text> ();
		text.text = "Final Score: " + GameParameters.score;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
