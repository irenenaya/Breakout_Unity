using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer renderer;
	int index;
	Animator anim;
	bool breakable = true;
    EffectSpawner fxSpawner;
	PowerUp powerup;
	Color[] particleColors = { Color.blue, Color.green, Color.red, Color.magenta, Color.yellow };

    void Awake () {
		renderer = GetComponent<SpriteRenderer> ();
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
        fxSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EffectSpawner>();		// audio = GetComponent<AudioSource> ();

	}

	public void SetTier (int tier) {
		index = tier-1;
		renderer.sprite = sprites [index];
		if (index == sprites.Length - 1)
			breakable = false;
	}


	public void changeBreakable() {
		index = Mathf.Min(GameParameters.level + 1 , 19);
		renderer.sprite = sprites [index];
		breakable = true;
	}

	public void setPowerup(PowerUp p) {
		powerup = p;
	}
	// On Collision, change sprite or remove brick. Also, increase score. 
	// TODO: Make the Score Great Again :p
	void OnCollisionEnter2D(Collision2D coll) {		
		int ind = index;
		fxSpawner.RunEffectAt(new Vector2(transform.position.x, transform.position.y), 
			particleColors[ind % 5]);	
		if (!breakable) {
			powerup.gameObject.SetActive (true);
			return;
		}
			
		if (index > 0) {			
			renderer.sprite = sprites [--index];
			GameParameters.score += (index + 1) * 10;
			if (powerup != null) 
				powerup.gameObject.SetActive (true);
        }
		else {
			int temp = anim.GetInteger ("Bricks");
			anim.SetInteger ("Bricks", --temp);
			GameParameters.score += 200;
            Destroy (gameObject);
		}
        	
    }

}
