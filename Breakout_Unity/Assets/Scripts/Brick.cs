using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer renderer;
	int index;
	Animator anim;

	// Use this for initialization
	void Awake () {
		renderer = GetComponent<SpriteRenderer> ();
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
	}

	public void SetTier (int tier) {
		index = tier;
		renderer.sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	// On Collision, change sprite or remove brick. Also, increase score. 
	// TODO: Make the Score Great Again :p
	void OnCollisionEnter2D(Collision2D coll) {
		if (index > 0) {
			renderer.sprite = sprites [--index];
			GameParameters.score += (index + 1) * 10;

		}
		else {
			int temp = anim.GetInteger ("Bricks");
			anim.SetInteger ("Bricks", --temp);
			GameParameters.score += 200;
			Destroy (gameObject);
		}
	}
}
