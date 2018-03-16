using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeStateBehaviour : GeneralStateBehaviour {

    public float speed = 3.0f;
    public float halfAngle = 80.0f;

    public Ball ballPrefab;

	Ball ball;
	public PlayUI playUIController;
	public Paddle paddleController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		removePowerUps ();
        ball = Instantiate(ballPrefab, new Vector2(0, SceneConstants.BALLY), Quaternion.identity);
        ball.SetPosition (paddleController.position);
		ball.SetVelocity (new Vector2 (0, 0));
		animator.SetInteger ("BallsCount", animator.GetInteger ("BallsCount") + 1);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		ball.SetPosition (paddleController.position);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

		ball.SetVelocity(new Vector2(0, speed));
		ball.AddAngle(Random.Range(-halfAngle, halfAngle));
		playUIController.HideUI ();

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
