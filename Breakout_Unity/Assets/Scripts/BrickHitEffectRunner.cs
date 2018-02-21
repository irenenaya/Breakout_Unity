using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHitEffectRunner : MonoBehaviour
{
    AudioSource sound;
    ParticleSystem particles;

	// Use this for initialization
	void Start()
    {
        sound = GetComponent<AudioSource>();
        // sound.Stop();
	}

    public void Run()
    {
        sound.Play();
    }
}
