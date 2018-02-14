﻿using UnityEngine;
using UnityEngine.UI;
using MenuHandlers;


/* Example of the controller for the individual scenes. For now, i attached it to the UI
 * element of the StartScene, but it could (should?) be a separate object. 
 * Just did this to remember how to interact with the SceneController and Behaviours
 * StartStateBehaviour is the class that is attached to the StartState state in
 * the Animator Controller */


public class StartSceneController : MonoBehaviour
{
    // Variable to hold a reference to the animator controller and to the StateBehaviour
    Animator anim;
    public Text Highscore;
    public Text StartGame;

    public Text[] data;

    CircularMenuHandler menu;

    void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        anim = obj.GetComponent<Animator>();

        // callbacks that change color of menu items, pass to constructor
        SetItemCB changeToCyan = x => { x.color = Color.cyan; };
        SetItemCB changeToWhite = x => { x.color = Color.white; };

        menu = new CircularMenuHandler(data, changeToCyan, changeToWhite);
    }
	
	// Update is called once per frame
	void Update()
    {

        bool up = InputHandle.Up;
        bool down = InputHandle.Down;

        if (up)
        {            
            menu.HighlightPrev();
        }
        else if (down)
        {
            menu.HighlightNext();
        }

        if (up || down)
        {
            anim.SetInteger("ChooseNextState", menu.CurrentIndex());
        }
	}
}
