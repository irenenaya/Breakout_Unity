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
}
