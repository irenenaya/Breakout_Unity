using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/*
 * Handles the behaviour of all Powerups that are instantiated in the game. 
 * They get instantiated from LevelLoader. Because different powerups will have
 * behaviours that affect different aspects of the gameplay, we are using UnityAction objects, which
 * work as function objects, to call specific functions for each powerup. 
 * Powerups are placed in the scene as an array so that the index == action index == PowerupConstants enum value
*/
public class PowerUp : MonoBehaviour
{
    public Sprite[] sprites;
    public Ball ball;
    SpriteRenderer rend;
    Brick brick;
    Paddle paddle;
    Animator anim;
    Rigidbody2D rigby;
    UnityAction[] actions = new UnityAction[5];
    int index;

    // called from the Brick class to pair the Powerup to its brick
    public void setBrick(Transform br) {
        brick = br.GetComponent<Brick> ();
    }

    // Powerups are instantiated in LevelLoader and disabled, so we initialize them in OnEnable()
    public void OnEnable() {
        rend = GetComponent<SpriteRenderer> ();
        rigby = GetComponent<Rigidbody2D> ();
        rigby.velocity = new Vector2 (0, -1.5f);
        paddle = GameObject.FindGameObjectWithTag ("Player").GetComponent<Paddle> ();
        anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
        actions [0] = increaseLives;
        actions [1] = enlargePaddle;
        actions [2] = shrinkPaddle;
        actions [3] = addBall;
        actions [4] = breakBrick;
    }

    public void setSprite (int type) {
        rend.sprite = sprites [type];
        index = type;
    }
    // When the Powerup collides with Paddle ("Player"), we call the corresponding function and destroy it.
    // Otherwise we call cleanup() because it left the screen. 
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {            
            actions[index]();
            Destroy (gameObject);
        }
        else if (other.gameObject.tag == "BottomBound") {
            cleanUp ();
        }
            
    }
    // If the Powerup is the KEY, we send it back to its brick. Other Powerups we just destroy
    public void cleanUp() {
        if (index == (int)PowerUpConstants.KEY) {
            transform.SetPositionAndRotation (brick.transform.position, Quaternion.identity);
            gameObject.SetActive (false);
        } else
            Destroy (gameObject);
    }

/* ----------------------------------------------------------------------------------------------
 * Actions
 * ----------------------------------------------------------------------------------------------*/

    // For KEY Powerup. It calls method on the Brick class
    void breakBrick() {
        brick.changeBreakable ();
    }

    void increaseLives() {
        if (anim.GetInteger ("Lives") < 3)
            anim.SetInteger ("Lives", anim.GetInteger ("Lives") + 1);
    }

    void shrinkPaddle() {
        paddle.DecreaseSize ();
    }

    void enlargePaddle() {
        paddle.IncreaseSize ();
    }

    void addBall() {
        Ball b = Instantiate (ball, new Vector2 (0, SceneConstants.BALLY), Quaternion.identity);
        anim.SetInteger ("BallsCount", anim.GetInteger ("BallsCount") + 1);
        b.SetPosition (paddle.transform.position);
        b.Serve ();
    }
}
