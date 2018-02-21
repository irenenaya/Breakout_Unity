using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayUI : MonoBehaviour {

	public GameObject texts;
	public Text score;
	public Text level;
	public Image[] hearts;
	public Sprite[] heartSprites;

	ServeStateBehaviour behaviour;
	LoadLevelStateBehaviour loadBehaviour;
	Animator anim;
	// Use this for initialization
	void Start () {
		
		level.text = "Level " + GameParameters.level;
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
		loadBehaviour = anim.GetBehaviour<LoadLevelStateBehaviour> ();
		behaviour.playUIController = this;
		loadBehaviour.playUIController = this;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = "Score: " + GameParameters.score;
		for (int i = 0; i < 3; ++i) {
			if (i < anim.GetInteger("Lives"))
				hearts [i].sprite = heartSprites [0];
			else
				hearts [i].sprite = heartSprites [1];
		}
	}

	public void HideUI() {
		texts.SetActive (false);
	}

	public void showUI() {
		texts.SetActive (true);
	}
}
