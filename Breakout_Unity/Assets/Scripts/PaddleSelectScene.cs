using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		GameParameters.paddleIndex = index + 4;
	}
	
	// Update is called once per frame
	void Update () {
		if (InputHandle.Right) {
			if (index < paddles.Length - 1)
				++index;
			paddle.sprite = paddles [index];
			GameParameters.paddleIndex = index + 4;
			rightArrow.color = index == paddles.Length - 1 ? Color.gray : Color.white;
			leftArrow.color = Color.white;

		}
		else if (InputHandle.Left) {
			if (index > 0)
				--index;
			paddle.sprite = paddles [index];
			GameParameters.paddleIndex = index + 4;
			leftArrow.color = index == 0 ? Color.gray : Color.white;
			rightArrow.color = Color.white;
		}
	}
}
