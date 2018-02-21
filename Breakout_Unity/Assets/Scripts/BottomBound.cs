using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBound : MonoBehaviour {

	Animator anim;
	AudioSource audio;
	// Use this for initialization
	void Start () {
		anim = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D coll)
	{
		anim.SetTrigger ("LifeLost");
		anim.SetInteger("Lives", anim.GetInteger("Lives") - 1);
		audio.Play ();
	}

}
