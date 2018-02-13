using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	Animator anim;
	// Just testing correct loading of the StartScene. 
	void Awake () {
		anim = GetComponent<Animator> ();
		SceneManager.LoadSceneAsync ("StartScene", LoadSceneMode.Additive);
		Debug.Log ("SceneLoaded");

	}
	
	// Update is called once per frame
	void Update () {
		if (InputHandle.Enter) {
			anim.SetTrigger ("EnterPressed");
		}
	}
}
