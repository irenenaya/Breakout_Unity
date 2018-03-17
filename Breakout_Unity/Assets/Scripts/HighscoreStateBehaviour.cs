using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Activates ScoresDisplay */
public class HighscoreStateBehaviour : GeneralStateBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		// TODO: This one gives error when we're not coming from Start scene. Works ok, though
		if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1).Equals(SceneManager.GetSceneByName(SceneConstants.START))) {
			controller.UnloadScene (SceneConstants.START);
			controller.activateObject("Highscores", true);
		}


	}
	// gets called from EnterHighscoreStateBehaviour. Had to do this because OnStateEnter from this behaviour 
	// gets called BEFORE the previous behaviour's OnStateExit finishes getting the scores from the handler.
	// It's messy and needs to be fixed!!! TODO!!!!! 
	public void showHighscores() 
	{
		controller.activateObject("Highscores", true);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		controller.activateObject ("Highscores", false);
		//controller.LoadNextScene (SceneConstants.START);
		//animator.ResetTrigger ("EnterPressed");
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
