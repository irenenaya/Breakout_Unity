﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterHighscoreStateBehaviour : GeneralStateBehaviour {
	// reference to the display UI
	public EnterInitialsDisplay display;
	HighscoreStateBehaviour behaviour;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		controller.activateObject ("EnterHighscore", true);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	/* It gets called when the user presses Enter after having entered their initials.
	 * Here we retrieve the initials from the display, and we get the score and add the score to the 
	 * handler
	 */
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
		controller.activateObject ("EnterHighscore", false);
		Text[] initials = display.getInitials ();
		string name = initials [0].text + initials [1].text + initials [2].text; 
		HighScoreHandler handler = controller.GetComponent<HighScoreHandler> ();
		handler.AddScore (name, GameParameters.score);
		// get a reference to the next behaviour. Explained in HighscoreStateBehaviour
		behaviour = animator.GetBehaviour<HighscoreStateBehaviour> ();
		behaviour.showHighscores ();
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}