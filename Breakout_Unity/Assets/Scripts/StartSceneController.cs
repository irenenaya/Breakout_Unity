using UnityEngine;
using UnityEngine.UI;
using MenuHandlers;


/* 
 * Displays the initial screen of the game, showing the two options: Start / Highscores
 */

public class StartSceneController : MonoBehaviour
{
    // Variable to hold a reference to the animator controller 
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
        anim.SetInteger("ChooseNextState", menu.CurrentIndex());
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
