using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServeStateBehaviour : GeneralStateBehaviour {

	public Ball ballController;
	public PlayUI playUIController;
	public Paddle paddleController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		ballController.SetPosition (paddleController.position);
		ballController.SetVelocity (new Vector2 (0, 0));
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		ballController.SetPosition (paddleController.position);
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		ballController.SetVelocity(new Vector2(0, 3));
		ballController.AddAngle(Random.Range(-80.0f, 80.0f));
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
