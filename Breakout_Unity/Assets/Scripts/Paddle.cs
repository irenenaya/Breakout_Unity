using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [System.Serializable]
    public class ColourPaddle
    {
        public Sprite[] sprites;
        public Sprite this[int i]
        {
            get { return sprites[i]; }
            set { sprites[i] = value; }
        }

        public int Length
        {
            get { return sprites.Length; }
            private set { }
        }
    }

    public ColourPaddle[] paddleSprites;
    public int spriteIndex = 1;
	public float speed;
	public float leftLimit;
	public float rightLimit;
    public float axisDeadZone = 0.1f;
	public Vector2 position {
		get { return transform.position; }
		private set { }
	}

    public Vector2 velocity { get; private set; }

	Vector2 newPos;
	Animator anim;
	AudioSource audio;
	ServeStateBehaviour behaviour;
	SpriteRenderer rend;
	BoxCollider2D coll;
    Vector2 oldPos;

	// Use this for initialization
	void Awake () {
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		coll = GetComponent<BoxCollider2D> ();
		rend = GetComponent<SpriteRenderer> ();
		rend.sprite = paddleSprites[GameParameters.paddleIndex][spriteIndex];
		newPos.y = -4;
		audio = GetComponent<AudioSource> ();
	}

	void Start() {
		behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
		behaviour.paddleController = this;
	}
	
	// Update is called once per frame
	void Update () {
        oldPos = new Vector2(transform.position.x, transform.position.y);
        float move = InputHandle.Horizontal;

        if (Mathf.Abs(move) > axisDeadZone)
        {
            float step = move * speed * Time.deltaTime;
            newPos.x = oldPos.x + step;
            newPos.x = Mathf.Clamp(newPos.x, leftLimit, rightLimit);
            transform.SetPositionAndRotation(newPos, Quaternion.identity);
        }
        else
        {
            newPos = oldPos;
        }

        velocity = (newPos - oldPos) / Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		audio.Play ();
	}

	public void IncreaseSize()
    {
		Debug.Log ("Size Up");
        if (spriteIndex < paddleSprites[GameParameters.paddleIndex].Length)
        {
            ++spriteIndex;
            rend.sprite = paddleSprites[GameParameters.paddleIndex][spriteIndex];
            coll.size = new Vector2(coll.size.x + 0.32f, coll.size.y); 
        }
	}

	public void DecreaseSize()
    {
		Debug.Log ("Size Down");
        if (spriteIndex > 0)
        {
            --spriteIndex;
            rend.sprite = paddleSprites[GameParameters.paddleIndex][spriteIndex];
            coll.size = new Vector2(coll.size.x - 0.32f, coll.size.y);
        }
    }
}
