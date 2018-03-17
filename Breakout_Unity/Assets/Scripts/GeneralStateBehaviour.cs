using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
/*	protected void cleanTriggers() {

	}*/
}
