using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Main UI that will be displayed during gamePlay. It has some elements (score, level, lives) that will 
 * be present while we're playing, and others like the current Level, which only appear when the game is in
 * some states. The corresponding StateMachineBehaviours handle which elements are shown or hidden.
*/
public class PlayUI : MonoBehaviour {

    public GameObject texts;
    public Text score;
    public Text level;
    public Image[] hearts;
    public Sprite[] heartSprites;

    ServeStateBehaviour behaviour;
    LoadLevelStateBehaviour loadBehaviour;
    VictoryStateBehaviour victoryBehaviour;
    Animator anim;
    // Use this for initialization
    void Start () {
        
        level.text = "Level " + GameParameters.level;
        anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
        behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
        loadBehaviour = anim.GetBehaviour<LoadLevelStateBehaviour> ();
        victoryBehaviour = anim.GetBehaviour<VictoryStateBehaviour> ();
        behaviour.playUIController = this;
        loadBehaviour.playUIController = this;
        victoryBehaviour.playUIController = this;
    }
    
    // Update is called once per frame
    void Update () {
        score.text = "Score: " + GameParameters.score;
        for (int i = 0; i < 3; ++i) {
            if (i < anim.GetInteger("Lives"))
                hearts [i].sprite = heartSprites [0];
            else
                hearts [i].sprite = heartSprites [1];
        }
    }

    public void HideUI() {
        texts.SetActive (false);
    }

    public void showUI() {
        texts.SetActive (true);
    }

    public void setVictoryText() {
        level.text = "Level " + GameParameters.level + " Completed!";
    }
}
