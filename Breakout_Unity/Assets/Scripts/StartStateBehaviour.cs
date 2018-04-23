using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStateBehaviour : GeneralStateBehaviour {

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter (animator, stateInfo, layerIndex);
        controller.LoadNextScene (SceneConstants.START);

        // initializing global game state before the start
        animator.SetInteger("Lives", 3);
        GameParameters.score = 0;
        GameParameters.level = 1;
    }

}
