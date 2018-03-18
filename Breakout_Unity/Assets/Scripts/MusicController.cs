using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource music;
    IEnumerator pitchTransitionCoroutine;

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

    public void PitchTransition(float target, float duration)
    {
        if (pitchTransitionCoroutine != null)
        {
            StopCoroutine(pitchTransitionCoroutine);
        }
        pitchTransitionCoroutine = PitchTransitionCoroutine(target, duration);
        StartCoroutine(pitchTransitionCoroutine);
    }

    IEnumerator PitchTransitionCoroutine(float target, float duration)
    {
        float from = music.pitch;
        float currStep = Time.deltaTime / duration;

        float invDuration = 1 / duration;

        while (Mathf.Abs(music.pitch - target) > 0.0f)
        {
            music.pitch = Mathf.Lerp(from, target, currStep);
            currStep += Time.deltaTime * invDuration;
            yield return null;
        }

        pitchTransitionCoroutine = null;
    }

}
