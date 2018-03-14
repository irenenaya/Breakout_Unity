using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Sprite[] sprites;

    Rigidbody2D rigidbod;
    new CircleCollider2D collider;
    new SpriteRenderer renderer;

	ServeStateBehaviour behaviour;
	VictoryStateBehaviour victBehaviour;
	Animator anim;
	AudioSource sounds;

    Paddle paddle;

    // Use this for initialization
    void Awake()
    {
        rigidbod = gameObject.GetComponent<Rigidbody2D>();
        collider = gameObject.GetComponent<CircleCollider2D>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
		sounds = GetComponent<AudioSource> ();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator>();
		//anim.SetInteger ("BallsCount", anim.GetInteger ("BallsCount") + 1);
	}

	void Start()
	{
		behaviour = anim.GetBehaviour<ServeStateBehaviour> ();
		behaviour.ballController = this;
		victBehaviour = anim.GetBehaviour<VictoryStateBehaviour> ();
		victBehaviour.ballController = this;
        paddle = GameObject.FindGameObjectWithTag("Player").GetComponent<Paddle>();
	}


    private void OnCollisionExit2D(Collision2D collision)
    {
		if (collision.collider.CompareTag ("Boundaries")) {
			sounds.Play ();
			AddAngleConserveQuadrant (Random.Range (-5.0f, 5.0f));
    
			// a hack to prevent shallow bounces from boundaries
			// Debug.Log("angle from x pre: " + Mathf.Asin(rigidbody.velocity.y / rigidbody.velocity.magnitude) * Mathf.Rad2Deg);
			Vector2 velocity = rigidbod.velocity;
			if (Mathf.Abs (Mathf.Asin (velocity.y / velocity.magnitude)) * Mathf.Rad2Deg < 15.0f) {
				AddAngle (Random.Range (5.0f, 10.0f) * -Mathf.Sign (velocity.y) * Mathf.Sign (velocity.x));
				// Debug.Log("angle from x: " + Mathf.Asin(rigidbody.velocity.y / rigidbody.velocity.magnitude) * Mathf.Rad2Deg);
			}
		} else if (collision.collider.CompareTag ("Player")) {
			// TODO get paddle velocity, not input
			AddAngleConserveYDirection (2.0f * paddle.velocity.x);
			// Debug.Log(paddle.velocity.x);
		} else {
			AddAngleConserveQuadrant (Random.Range (-10.0f, 10.0f));

		}
    }

    // use to set velocity, for example initial velocity
    public void SetVelocity(Vector2 vel)
    {
        rigidbod.velocity = vel;
    }

    // add angle in degrees, changes velocity direction but keeps magnitude
	// TODO: Should maybe be clamped? If the angle is shallow enough, the ball will bounce in the
	// same direction as it was coming. 
    public void AddAngle(float deltaAngle)
    {
        Vector2 velocity = rigidbod.velocity;
        float absVelocity = velocity.magnitude;
        float angleRad = (Vector2.SignedAngle(velocity, Vector2.up) + deltaAngle) * Mathf.Deg2Rad;
        float x = absVelocity * Mathf.Sin(angleRad);
        float y = absVelocity * Mathf.Cos(angleRad);
        rigidbod.velocity = new Vector2(x, y);
    }

    // add angle in degrees, changes velocity direction but keeps magnitude allowing the ball
    // to travel in the same direction
    public void AddAngleConserveQuadrant(float deltaAngle)
    {
        Vector2 velocity = rigidbod.velocity;
        float absVelocity = velocity.magnitude;      
        float angleRad = (Vector2.SignedAngle(velocity, Vector2.up) + deltaAngle) * Mathf.Deg2Rad;
        float x = absVelocity * Mathf.Sin(angleRad);
        float y = absVelocity * Mathf.Cos(angleRad);

        // conserve quadrant
        x = x > 0.0f == velocity.x > 0.0f ? x : -x;
        y = y > 0.0f == velocity.y > 0.0f ? y : -y;

        rigidbod.velocity = new Vector2(x, y);
    }


    public void AddAngleConserveYDirection(float deltaAngle)
    {
        Vector2 velocity = rigidbod.velocity;
        float absVelocity = velocity.magnitude;
        float angleRad = (Vector2.SignedAngle(velocity, Vector2.up) + deltaAngle) * Mathf.Deg2Rad;
        float x = absVelocity * Mathf.Sin(angleRad);
        float y = absVelocity * Mathf.Cos(angleRad);
        y = y > 0.0f == velocity.y > 0.0f ? y : -y;
        rigidbod.velocity = new Vector2(x, y);
    }


    void SetVelocityMagnitude(float magnitude)
    {
        rigidbod.velocity = rigidbod.velocity.normalized * magnitude;
    }

    // simple change in velocity, multiplies velocity by constant factor
    void MultiplyVelocity(float mult)
    {
        rigidbod.velocity *= mult;
    }

	public void SetPosition(Vector2 pos)
	{
		Vector2 temp;
		temp.x = pos.x;
		temp.y = SceneConstants.BALLY;
		transform.SetPositionAndRotation(temp, Quaternion.identity);
	}

	void Update () {
		if (InputHandle.Pause) {
			SetVelocity (new Vector2 (0, 0));
		}
	}
}
