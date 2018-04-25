using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Base class for all StateMachineBehaviours
 * It holds a reference to the SceneController, so that all derived classes can access it. 
 * It also removes powerups that might stay behind when we finish a level, and resets all 
 * triggers that might not have been used (mostly due to undesired user input)
 */
public class GeneralStateBehaviour : StateMachineBehaviour {

    public SceneController controller;

    protected void removePowerUps() {
        GameObject[] powerUps = GameObject.FindGameObjectsWithTag("PowerUp");
        foreach (var pUp in powerUps) {
            PowerUp p = pUp.GetComponent<PowerUp> ();
            p.cleanUp ();
        }
    }

    public override void OnStateEnter (Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimatorControllerParameter[] pars = animator.parameters;
        foreach (var p in pars) {
            if (p.type == AnimatorControllerParameterType.Trigger) {
                animator.ResetTrigger (p.name);
            }
        }
    }
}
