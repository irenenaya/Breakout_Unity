using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer rend;
	Brick brick;
	string[] type = { PowerUpConstants.EXTRA_LIFE, PowerUpConstants.ENLARGE_PADDLE, PowerUpConstants.SHRINK_PADDLE,
		PowerUpConstants.KEY
	};
	// Use this for initialization
	void Awake () {
		rend = GetComponent<SpriteRenderer> ();
		Rigidbody2D rigby = GetComponent<Rigidbody2D> ();
		rigby.velocity = new Vector2 (0, -0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setBrick(Transform br) {
		brick = br.GetComponent<Brick> ();
	}
	public void setSprite (string type) {
		rend.sprite = sprites [type.IndexOf (type)];
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			brick.changeBreakable ();
		}
		if (other.gameObject.tag == "Boundaries") {
			Destroy (gameObject);
		}
	}
}
