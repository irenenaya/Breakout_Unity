using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseStateBehaviour : GeneralStateBehaviour
{
    MusicController backgroundMusic;
    float originalPitch;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
		base.OnStateEnter(animator, stateInfo, layerIndex);
        backgroundMusic = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<MusicController>();
        originalPitch = backgroundMusic.pitch;
        backgroundMusic.PitchTransition(0.0f, 0.5f);
        Time.timeScale = 0.0f;
		controller.activateObject ("PauseUI", true);
		GameObject.Find ("CheatMachine").GetComponent<CheatMachine> ().enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (InputHandle.Pause) animator.SetBool("Paused", false);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Time.timeScale = 1.0f;
        backgroundMusic.PitchTransition(originalPitch, 0.5f);
        controller.activateObject ("PauseUI", false);
		GameObject.Find ("CheatMachine").GetComponent<CheatMachine> ().enabled = true;
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