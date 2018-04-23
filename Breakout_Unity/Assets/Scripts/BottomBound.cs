﻿using System.Collections;
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


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Ball") {
            anim.SetInteger("BallsCount", anim.GetInteger("BallsCount") - 1);
            if (anim.GetInteger("BallsCount") == 0) {
                anim.SetInteger ("Lives", anim.GetInteger ("Lives") - 1);
            }

            Destroy (coll.gameObject);
            audio.Play ();
        }
    }

}
