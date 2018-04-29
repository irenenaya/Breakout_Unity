using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * State triggered every time the player will serve, either at the beginning of a level or when
 * they just lost a life. It removes powerups (if any), and reinstantiates the ball and positions it
*/
public class ServeStateBehaviour : GeneralStateBehaviour {
    
    public Ball ballPrefab;

    Ball ball;
    public PlayUI playUIController;
    public Paddle paddleController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter (animator, stateInfo, layerIndex);
        removePowerUps ();
        ball = Instantiate(ballPrefab, new Vector2(0, SceneConstants.BALLY), Quaternion.identity);
        ball.SetPosition (paddleController.position);
        ball.SetVelocity (new Vector2 (0, 0));
        // Why did we need this again? Can't we just set to 1?
        // animator.SetInteger ("BallsCount", animator.GetInteger ("BallsCount") + 1);
        animator.SetInteger("BallsCount", 1);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        ball.SetPosition (paddleController.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        ball.Serve ();

        playUIController.HideUI ();

    }
}
