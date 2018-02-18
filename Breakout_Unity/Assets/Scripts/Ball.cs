﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;

    new Rigidbody2D rigidbody;
    new CircleCollider2D collider;
    new SpriteRenderer renderer;

    // Use this for initialization
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
	}

    // Update is called once per frame
    void Update()
    {

    }

    // use to set velocity, for example initial velocity
    void SetVelocity(Vector2 vel)
    {
        rigidbody.velocity = vel;
    }

    // add angle in degrees, changes velocity direction but keeps magnitude
    void AddAngle(float deltaAngle)
    {
        Vector2 velocity = rigidbody.velocity;
        float absVelocity = velocity.magnitude;

        float angleRad = Mathf.Tan(velocity.y / velocity.x) + deltaAngle * Mathf.Deg2Rad;
        float x = absVelocity * Mathf.Acos(angleRad);
        float y = absVelocity * Mathf.Asin(angleRad);

        rigidbody.velocity = new Vector2(x, y);
    }

    void SetVelocityMagnitude(float magnitude)
    {
        rigidbody.velocity = rigidbody.velocity.normalized * magnitude;
    }

    // simple change in velocity, multiplies velocity by constant factor
    void MultiplyVelocity(float mult)
    {
        rigidbody.velocity *= mult;
    }
}
