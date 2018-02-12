using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Example of the controller for the individual scenes. For now, i attached it to the UI
 * element of the StartScene, but it could (should?) be a separate object. 
 * Just did this to remember how to interact with the SceneController and Behaviours
 * StartStateBehaviour is the class that is attached to the StartState state in
 * the Animator Controller */


public class StartSceneController : MonoBehaviour {
	// Variable to hold a reference to the animator controller and to the StateBehaviour
	Animator anim;
	StartStateBehaviour behaviour;
	// Here we get the reference to the Animator component. It's inside the "SceneController" object
	// in the PersistentScene, and it's tagged "GameController"
	void Awake () {
		GameObject obj = GameObject.FindGameObjectWithTag ("GameController");
		anim = obj.GetComponent<Animator> ();
	}

	void Start() {
		// Tutorial says the behaviours should be acquired in Start, not Awake. We get the behaviour
		// asset and it has the "controller" variable, which is of the type of this class. Assigning
		// the variable to "this" allows the behaviour to hold a reference to this class, so we can
		// call funtions from the class
		behaviour = anim.GetBehaviour<StartStateBehaviour> ();
		behaviour.controller = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Test() {
		// What it says on the tin :p 
		Debug.Log ("This is called from Behaviour");
	}
}
