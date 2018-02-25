using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MenuHandlers;

public class EnterInitialsDisplay : MonoBehaviour {

	public Text[] initials;
	public Text score;
	CircularMenuHandler menu;
	EnterHighscoreStateBehaviour behaviour;
	Animator anim; 
	// Use this for initialization
	void Start () {
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		behaviour = anim.GetBehaviour<EnterHighscoreStateBehaviour> ();
		behaviour.display = this;
		SetItemCB changeToCyan = x => { x.color = Color.cyan; };
		SetItemCB changeToWhite = x => { x.color = Color.white; };

		menu = new CircularMenuHandler(initials, changeToCyan, changeToWhite);


	}

	void OnEnable() {
		score.text = "Your Score: " + GameParameters.score;
	}
	
	// Update is called once per frame
	void Update () {
		bool up = InputHandle.Up;
		bool down = InputHandle.Down;
		bool right = InputHandle.Right;
		bool left = InputHandle.Left;

		if (left)
		{            
			menu.HighlightPrev();
		}
		else if (right)
		{
			menu.HighlightNext();
		}
		else if (up) 
		{
			char curr = initials [menu.CurrentIndex ()].text [0];
			++curr;
			if ((int)curr > 90)
				curr = (char)65;
			initials [menu.CurrentIndex ()].text = curr.ToString ();
		}
		else if (down)
		{
			char curr = initials [menu.CurrentIndex ()].text [0];
			--curr;
			if ((int)curr < 65)
				curr = (char)90;
			initials [menu.CurrentIndex ()].text = curr.ToString ();
		}
	}
	public Text[] getInitials() 
	{
		return initials;
	}
}
