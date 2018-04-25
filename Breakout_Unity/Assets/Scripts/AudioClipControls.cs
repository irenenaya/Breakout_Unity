/**
 * AudioClipControls.cs - control the sounds in the object and allow for smooth (linear) transitions
 * in pitch and volume over time
 * 
 * The changes are done using coroutines, so that any kind of transition is "fire and forget," and 
 * if there is already a transition happening it gets interrupted and a new transition starts.
 * 
 * This script is attached to the background music game object and is called from CheatMachine and
 * from PauseStateBehaviour in the project
 * 
 * Note: changing pitch means modifying the speed, and consequentially the frequency, of the audio
 * clip.
 */

using System.Collections;
using UnityEngine;

public class AudioClipControls : MonoBehaviour
{
    AudioSource music;
    IEnumerator pitchTransitionCoroutine;   // coroutines that transition pitch are handed to this variable
    IEnumerator volumeTransitionCoroutine;  // coroutines transitioning volume are handed to this variable

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


    // call this function to set pitch directly, killing the pitch transition taking place first
    public void SetPitch(float pitch)
    {
        targetPitch = pitch;

        if (pitchTransitionCoroutine != null)
        {
            StopCoroutine(pitchTransitionCoroutine);
        }

        music.pitch = pitch;
    }


    // call this function to set volume directly, killing the volume transition taking place first
    public void SetVolume(float volume)
    {
        targetVolume = volume;

        if (volumeTransitionCoroutine != null)
        {
            StopCoroutine(volumeTransitionCoroutine);
        }

        music.volume = volume;
    }


    // change pitch to target frequency over duration seconds
    public void PitchTransition(float target, float duration)
    {
        targetPitch = target;

        if (pitchTransitionCoroutine != null)
        {
            StopCoroutine(pitchTransitionCoroutine);
        }

        if (duration <= Mathf.Epsilon && duration >= -Mathf.Epsilon)
        {
            SetPitch(target);
        }
        else
        {
            pitchTransitionCoroutine = PitchTransitionCoroutine(target, duration);
            StartCoroutine(pitchTransitionCoroutine);
        }
    }


    // change volume to target frequency over duration seconds
    public void VolumeTransition(float target, float duration)
    {
        targetVolume = target;

        if (volumeTransitionCoroutine != null)
        {
            StopCoroutine(volumeTransitionCoroutine);
        }

        if (duration <= Mathf.Epsilon && duration > 0)
        {
            SetVolume(target);
        }
        else
        {
            volumeTransitionCoroutine = VolumeTransitionCoroutine(target, duration);
            StartCoroutine(volumeTransitionCoroutine);
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
