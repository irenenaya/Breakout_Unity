using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleInitStateBehaviour : GeneralStateBehaviour {

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter (animator, stateInfo, layerIndex);
        controller.LoadNextScene (SceneConstants.GAME);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if(SceneManager.GetSceneByName(SceneConstants.GAME).IsValid()) {
            animator.SetTrigger ("GameSceneLoaded");
        }
    }

}
