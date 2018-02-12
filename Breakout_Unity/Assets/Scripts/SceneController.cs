using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

	// Just testing correct loading of the StartScene. 
	void Awake () {
		SceneManager.LoadSceneAsync ("StartScene", LoadSceneMode.Additive);
		Debug.Log ("SceneLoaded");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
