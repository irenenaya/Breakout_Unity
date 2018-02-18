using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public Sprite[] sprites;
	public float speed;
	public float leftLimit;
	public float rightLimit;
    public float axisDeadZone = 0.1f;
	Vector2 newPos;
	SpriteRenderer rend;
	BoxCollider2D coll;
	// Use this for initialization
	void Awake () {
		coll = GetComponent<BoxCollider2D> ();
		rend = GetComponent<SpriteRenderer> ();
		rend.sprite = sprites [GameParameters.paddleIndex];
		newPos.y = -4;
	}
	
	// Update is called once per frame
	void Update () {

        float move = InputHandle.Horizontal;

        if (Mathf.Abs(move) > axisDeadZone)
        {
            float step = move * speed * Time.deltaTime;
            newPos.x = transform.position.x + step;
            newPos.x = Mathf.Clamp(newPos.x, leftLimit, rightLimit);
            transform.SetPositionAndRotation(newPos, Quaternion.identity);
        }	
	}
}
