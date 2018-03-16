using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource music;

	void Awake()
    {
        music = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
    {
        if (InputHandle.Pause) music.pitch *= 0.95f;
	}
}
