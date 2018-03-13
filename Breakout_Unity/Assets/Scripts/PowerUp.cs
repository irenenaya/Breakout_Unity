using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer rend;
	Brick brick;
	Paddle paddle;
	Animator anim;
	Rigidbody2D rigby;
	UnityAction[] actions = new UnityAction[4];
	int index;
	/*string[] type = { PowerUpConstants.EXTRA_LIFE, PowerUpConstants.ENLARGE_PADDLE, PowerUpConstants.SHRINK_PADDLE,
		PowerUpConstants.KEY
	};*/
	// Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setBrick(Transform br) {
		brick = br.GetComponent<Brick> ();
	}

	public void OnEnable() {
		rend = GetComponent<SpriteRenderer> ();
		rigby = GetComponent<Rigidbody2D> ();
		rigby.velocity = new Vector2 (0, -1.5f);
		paddle = GameObject.FindGameObjectWithTag ("Player").GetComponent<Paddle> ();
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		actions [0] = increaseLives;
		actions [1] = enlargePaddle;
		actions [2] = shrinkPaddle;
		actions [3] = breakBrick;
	}

	public void setSprite (int type) {
		Debug.Log ("Set Sprite: " + type);
		rend.sprite = sprites [type];
		index = type;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {			
			actions[index]();
			Destroy (gameObject);
		}
		else if (other.gameObject.tag == "BottomBound") {
			if (index == (int)PowerUpConstants.KEY) {
				transform.SetPositionAndRotation (brick.transform.position, Quaternion.identity);
				gameObject.SetActive (false);
			} else
				Destroy (gameObject);
		}
	}

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
}
