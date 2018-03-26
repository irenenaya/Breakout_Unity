using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipControls : MonoBehaviour {
    AudioSource music;
    IEnumerator pitchTransitionCoroutine;
    IEnumerator volumeTransitionCoroutine;

    public float pitch
    {
        get { return music.pitch; }
        private set { }
    }

    public float volume
    {
        get { return music.volume; }
        private set { }
    }

    // check these to find where pitch and volume are headed in case of interrupting a transition
    public float targetPitch { get; private set; }
    public float targetVolume { get; private set; }


	void Awake()
    {
        music = GetComponent<AudioSource>();
		targetPitch = music.pitch;
        targetVolume = music.volume;
	}


    public void Pitch(float pitch)
    {
        targetPitch = pitch;

        if (pitchTransitionCoroutine != null)
        {
            StopCoroutine(pitchTransitionCoroutine);
        }

        music.pitch = pitch;
    }


    public void Volume(float volume)
    {
        targetVolume = volume;

        if (volumeTransitionCoroutine != null)
        {
            StopCoroutine(volumeTransitionCoroutine);
        }

        music.volume = volume;
    }


    public void PitchTransition(float target, float duration)
    {
        targetPitch = target;

        if (pitchTransitionCoroutine != null)
        {
            StopCoroutine(pitchTransitionCoroutine);
        }

        if (duration <= Mathf.Epsilon && duration >= -Mathf.Epsilon )
        {
            Pitch(target);
        }
        else
        {
            pitchTransitionCoroutine = PitchTransitionCoroutine(target, duration);
            StartCoroutine(pitchTransitionCoroutine);
        }
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
        targetVolume = target;

        if (volumeTransitionCoroutine != null)
        {
            StopCoroutine(volumeTransitionCoroutine);
        }

        if (duration <= Mathf.Epsilon && duration > 0)
        {
            Volume(target);
        }
        else
        {
            volumeTransitionCoroutine = VolumeTransitionCoroutine(target, duration);
            StartCoroutine(volumeTransitionCoroutine);
        }
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
