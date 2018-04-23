using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverStateBehaviour : GeneralStateBehaviour {

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		HighScoreHandler handler = controller.GetComponent<HighScoreHandler> ();
		animator.SetBool ("Highscorer", handler.DisplayData.Length < 10 || handler.DisplayData [9].score < GameParameters.score);
		controller.UnloadScene (SceneConstants.PLAY);
		controller.UnloadScene (SceneConstants.GAME);
		controller.activateObject ("GameOver", true);
	}

	 //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		controller.activateObject ("GameOver", false);		
	}

}
