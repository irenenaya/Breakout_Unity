using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Text text = GetComponent<Text> ();
		text.text = "Final Score: " + GameParameters.score;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
