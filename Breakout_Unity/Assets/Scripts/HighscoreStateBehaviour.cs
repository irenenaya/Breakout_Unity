using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Activates ScoresDisplay  */
public class HighscoreStateBehaviour : GeneralStateBehaviour {

     // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        base.OnStateEnter (animator, stateInfo, layerIndex);
        // If we're entering this State from the Start scene, we unload the scene and show the UI
        if (SceneManager.GetSceneAt(SceneManager.sceneCount - 1).Equals(SceneManager.GetSceneByName(SceneConstants.START))) {
            controller.UnloadScene (SceneConstants.START);
            controller.activateObject("Highscores", true);
        }


    }
    // gets called from EnterHighscoreStateBehaviour. Had to do this because OnStateEnter from this behaviour 
    // gets called BEFORE the previous behaviour's OnStateExit finishes getting the scores from the handler.

    public void showHighscores() 
    {
        controller.activateObject("Highscores", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        controller.activateObject ("Highscores", false);
    }

}
