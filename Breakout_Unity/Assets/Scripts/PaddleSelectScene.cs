using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Scene in which the player chooses which colour of paddle to play with
 * This could have been done as a full UI element
*/
public class PaddleSelectScene : MonoBehaviour {

    Animator anim;
    public Sprite[] paddles;
    public Image paddle;
    public Image leftArrow;
    public Image rightArrow;

    int index = 0;
    // Use this for initialization
    void Start () {
        GameObject obj = GameObject.FindGameObjectWithTag("GameController");
        anim = obj.GetComponent<Animator>();
        GameParameters.paddleIndex = index;
    }
    
    // Update is called once per frame
    void Update () {
        if (InputHandle.Right) {
            if (index < paddles.Length - 1)
                ++index;
            paddle.sprite = paddles [index];
            GameParameters.paddleIndex = index;
            rightArrow.color = index == paddles.Length - 1 ? Color.gray : Color.white;
            leftArrow.color = Color.white;

        }
        else if (InputHandle.Left) {
            if (index > 0)
                --index;
            paddle.sprite = paddles [index];
            GameParameters.paddleIndex = index;
            leftArrow.color = index == 0 ? Color.gray : Color.white;
            rightArrow.color = Color.white;
        }
    }
}
