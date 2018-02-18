using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;

    new CircleCollider2D collider;
    new SpriteRenderer renderer;
    // Use this for initialization
    void Awake()
    {
        collider = gameObject.GetComponent<CircleCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
	}
	
	// Update is called once per frame
	void Update()
    {
		
	}
}
