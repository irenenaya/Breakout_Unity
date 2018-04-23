using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryStateBehaviour : GeneralStateBehaviour {
	
	public PlayUI playUIController;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter (animator, stateInfo, layerIndex);
		playUIController.showUI ();
		playUIController.setVictoryText ();

        // remove all balls in level
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (var ball in balls) Destroy(ball);
		removePowerUps ();
		animator.SetInteger ("BallsCount", animator.GetInteger ("BallsCount") - 1);
		GameParameters.level++;
	}

}
