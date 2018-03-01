using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStateBehaviour : GeneralStateBehaviour {

	// Reference to the StartSceneController class which belongs to the Scene. Initialized in
	// the Start() function of the StartSceneController. 
	//public StartSceneController controller;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state

	// Calling function from the StartSceneController from the StateBehaviour. 
	// Works fine. This means that we can fairly easily pass things from the state machine to the
	// individual scenes. 
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		controller.LoadNextScene (SceneConstants.START);
        // TODO figure out where to put this, is it okay here?
        // initializing global game state before the start
        animator.SetInteger("Lives", 3);
		GameParameters.score = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
