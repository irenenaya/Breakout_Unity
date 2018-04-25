using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Used in transitions between levels. Unloads the previous PlayScene and loads a new one */
public class LoadLevelStateBehaviour : GeneralStateBehaviour
{
    public PlayUI playUIController;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter (animator, stateInfo, layerIndex);
        controller.UnloadScene (SceneConstants.PLAY);
        controller.AddScene (SceneConstants.PLAY);
    }

}
