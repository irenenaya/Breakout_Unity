using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * State triggered when player has removed all bricks.
 * It activates the PlayUI, and resets the state to start a new level
 */



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
        animator.SetInteger("BallsCount", 0);

        removePowerUps ();
        // Why did we need this again? Don't we just set to 1?
        // animator.SetInteger ("BallsCount", animator.GetInteger ("BallsCount") - 1);
        
        GameParameters.level++;
    }

}
