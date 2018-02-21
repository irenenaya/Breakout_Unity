using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public Sprite[] sprites;
	SpriteRenderer renderer;
	int index;
	Animator anim;
    EffectSpawner fxSpawner;
    // AudioSource audio;

    // Use this for initialization
    void Awake () {
		renderer = GetComponent<SpriteRenderer> ();
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
        fxSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EffectSpawner>();		// audio = GetComponent<AudioSource> ();

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
            // audio.Play ();     
        }
		else {
			int temp = anim.GetInteger ("Bricks");
			anim.SetInteger ("Bricks", --temp);
			GameParameters.score += 200;
            Destroy (gameObject);
			// TODO : Figure out a way to do this correctly!!!! 
			// renderer.enabled = false;
			// StartCoroutine("PlaySoundAndDestroy");
		}

        fxSpawner.PlaceAt(new Vector2(transform.position.x, transform.position.y));
    }

    /*
	IEnumerator PlaySoundAndDestroy() {
		// audio.Play ();
		// yield return new WaitForSeconds (audio.clip.length);
		Destroy (gameObject);
	}
    */
}
