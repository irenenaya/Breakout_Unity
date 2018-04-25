using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Handles Brick objects. It determines effects, sprites, powerups and particles associated with
 * the brick
*/
public class Brick : MonoBehaviour {

    public Sprite[] sprites;
    SpriteRenderer renderer;
    int index;
    Animator anim;
    // !breakable means KEY sprite is on. 
    bool breakable = true;
    EffectSpawner fxSpawner;
    PowerUp powerup;
    Color[] particleColors = { Color.blue, Color.green, Color.red, Color.magenta, Color.yellow };

    void Awake () {
        renderer = GetComponent<SpriteRenderer> ();
        anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
        fxSpawner = GameObject.FindGameObjectWithTag("GameController").GetComponent<EffectSpawner>();		// audio = GetComponent<AudioSource> ();

    }
    // sets the appropriate sprite from the sprites array in the inspector. The last sprite is the 
    // KEY one, so we set the brick to not breakable
    public void SetTier (int tier) {
        index = tier-1;
        renderer.sprite = sprites [index];
        if (index == sprites.Length - 1)
            breakable = false;
    }

    // Called by Powerup class when the KEY has been caught by the paddle. 
    public void changeBreakable() {
        index = Mathf.Min(GameParameters.level + 1 , 19);
        renderer.sprite = sprites [index];
        breakable = true;
    }

    public void setPowerup(PowerUp p) {
        powerup = p;
    }
    // On Collision, change sprite or remove brick. Also, increase score and run effects. 

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
