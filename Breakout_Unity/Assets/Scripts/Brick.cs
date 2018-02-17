using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer renderer;
	int index;

	// Use this for initialization
	void Awake () {
		renderer = GetComponent<SpriteRenderer> ();

	}

	public void SetTier (int tier) {
		index = tier;
		renderer.sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (index >= 0) {
			renderer.sprite = sprites [--index];
		}
		else {
			Destroy (gameObject);
		}
	}
}
