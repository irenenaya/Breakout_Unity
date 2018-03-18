using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource music;
    IEnumerator pitchTransitionCoroutine;
    IEnumerator volumeTransitionCoroutine;

    public float pitch
    {
        get { return music.pitch; }
        set { music.pitch = value; }
    }

    public float volume
    {
        get { return music.volume; }
        set { music.volume = value; }
    }

	void Awake()
    {
        music = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        /*
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
        */
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
        float invDuration = 1.0f / duration;
        float currStep = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(music.pitch - target) > 0.0f)
        {
            music.pitch = Mathf.Lerp(from, target, currStep);
            currStep += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }

    public void VolumeTransition(float target, float duration)
    {
        if (volumeTransitionCoroutine != null)
        {
            StopCoroutine(volumeTransitionCoroutine);
        }
        volumeTransitionCoroutine = VolumeTransitionCoroutine(target, duration);
        StartCoroutine(volumeTransitionCoroutine);
    }

    IEnumerator VolumeTransitionCoroutine(float target, float duration)
    {
        float from = music.volume;
        float invDuration = 1.0f / duration;
        float currStep = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(music.volume - target) > 0.0f)
        {
            music.volume = Mathf.Lerp(from, target, currStep);
            currStep += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }

}
