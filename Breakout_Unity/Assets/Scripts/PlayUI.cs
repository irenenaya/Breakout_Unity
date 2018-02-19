using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayUI : MonoBehaviour {

	public GameObject texts;

	ServeStateBehaviour behaviour;
	LoadLevelStateBehaviour loadBehaviour;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
		loadBehaviour = anim.GetBehaviour<LoadLevelStateBehaviour> ();
		behaviour.playUIController = this;
		loadBehaviour.playUIController = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void HideUI() {
		texts.SetActive (false);
	}

	public void showUI() {
		texts.SetActive (true);
	}
}
