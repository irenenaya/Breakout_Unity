using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource music;
    bool pitchTransitioning = false;

	void Awake()
    {
        music = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        // if (InputHandle.Pause) music.pitch *= 0.95f;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            PitchTransition(1.5f, 2f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PitchTransition(0.5f, 2f);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            PitchTransition(1.0f, 2f);
        }

    }

    void PitchTransition(float target, float duration)
    {
        if (pitchTransitioning) StopAllCoroutines();
        StartCoroutine(PitchTransitionCoroutine(target, duration));
    }

    IEnumerator PitchTransitionCoroutine(float target, float duration)
    {
        pitchTransitioning = true;
        float step = Time.deltaTime / duration;

        float from = music.pitch;
        float currStep = step;

        while (Mathf.Abs(music.pitch - target) > 0.0f)
        {
            music.pitch = Mathf.Lerp(from, target, currStep);
            currStep += step;
            yield return null;
        }

        pitchTransitioning = false;
    }

}
