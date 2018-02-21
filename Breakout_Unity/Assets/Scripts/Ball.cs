using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;

    new Rigidbody2D rigidbody;
    new CircleCollider2D collider;
    new SpriteRenderer renderer;

	ServeStateBehaviour behaviour;
	Animator anim;

    // Use this for initialization
    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator>();
	}

	void Start()
	{
		behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
		behaviour.ballController = this;
	}

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Boundaries")) AddAngle(Random.Range(-5.0f, 5.0f));
        else AddAngle(Random.Range(-10.0f, 10.0f));

    }

    // use to set velocity, for example initial velocity
    public void SetVelocity(Vector2 vel)
    {
        rigidbody.velocity = vel;
    }

    // add angle in degrees, changes velocity direction but keeps magnitude
	// TODO: Should maybe be clamped? If the angle is shallow enough, the ball will bounce in the
	// same direction as it was coming. 
    public void AddAngle(float deltaAngle)
    {
        Vector2 velocity = rigidbody.velocity;
        float absVelocity = velocity.magnitude;
        float angleRad = (Vector2.SignedAngle(velocity, Vector2.up) + deltaAngle) * Mathf.Deg2Rad;
        float x = absVelocity * Mathf.Sin(angleRad);
        float y = absVelocity * Mathf.Cos(angleRad);
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

	public void SetPosition(Vector2 pos)
	{
		Vector2 temp;
		temp.x = pos.x;
		temp.y = SceneConstants.BALLY;
		transform.SetPositionAndRotation(temp, Quaternion.identity);
	}
}
