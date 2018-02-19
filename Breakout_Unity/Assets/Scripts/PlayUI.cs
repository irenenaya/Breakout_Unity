﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour {

	public GameObject texts;
	public Text score;

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
		score.text = "Score: " + GameParameters.score;
	}

	public void HideUI() {
		texts.SetActive (false);
	}

	public void showUI() {
		texts.SetActive (true);
	}
}
