using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoresDisplay : MonoBehaviour {

	public GameObject canvas;
	public GameObject parent;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 10; ++i) {
			GameObject temp = Instantiate (canvas);
			temp.transform.SetParent (parent.transform, false);
			temp.transform.GetChild (0).gameObject.GetComponent<Text> ().text = (i +1) + ".";
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
