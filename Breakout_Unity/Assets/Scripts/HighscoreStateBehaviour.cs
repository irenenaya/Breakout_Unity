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

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		controller.activateObject ("Highscores", false);
	}

}
