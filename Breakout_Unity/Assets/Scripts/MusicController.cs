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

    // check these to find where pitch and volume are headed and where from in case of interrupting a transition
    public float preTransitionPitch { get; private set; }
    public float preTransitionVolume { get; private set; }
    public float targetPitch { get; private set; }
    public float targetVolume { get; private set; }

    public bool PitchTransitionDone()
    {
        return pitch == targetPitch;
    }

    public bool VolumeTransitionDone()
    {
        return volume == targetVolume;
    }

    public bool TransitionDone()
    {
        return PitchTransitionDone() && VolumeTransitionDone();
    }


	void Awake()
    {
        music = GetComponent<AudioSource>();
		targetPitch = music.pitch;
	}


    public void PitchTransition(float target, float duration)
    {
        if (PitchTransitionDone()) preTransitionPitch = pitch;
        targetPitch = target;

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
        if (VolumeTransitionDone()) preTransitionVolume = volume;
        targetVolume = target;

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
