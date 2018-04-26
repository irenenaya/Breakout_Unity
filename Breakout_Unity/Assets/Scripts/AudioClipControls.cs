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
    new AudioSource audio;
    IEnumerator pitchCoroutine;   // coroutines that transition pitch are handed to this variable
    IEnumerator volumeCoroutine;  // coroutines transitioning volume are handed to this variable

    public float pitch
    {
        get { return audio.pitch; }
        private set { }
    }

    public float volume
    {
        get { return audio.volume; }
        private set { }
    }

    // check these to find where pitch and volume are headed in case of interrupting a transition
    public float targetPitch { get; private set; }
    public float targetVolume { get; private set; }


    void Awake()
    {
        audio = GetComponent<AudioSource>();
        targetPitch = audio.pitch;
        targetVolume = audio.volume;
    }


    // call this function to set pitch directly, killing the pitch transition taking place first
    public void SetPitch(float pitch)
    {
        targetPitch = pitch;

        if (pitchCoroutine != null)
        {
            StopCoroutine(pitchCoroutine);
        }

        audio.pitch = pitch;
    }


    // call this function to set volume directly, killing the volume transition taking place first
    public void SetVolume(float volume)
    {
        targetVolume = volume;

        if (volumeCoroutine != null)
        {
            StopCoroutine(volumeCoroutine);
        }

        audio.volume = volume;
    }


    // change pitch to target frequency over duration seconds
    public void PitchTransition(float target, float duration)
    {
        // set targetPitch variable to allow access to desired pitch to any object modifying it while coroutine is active
        targetPitch = target;

        // stop any pitch transitions before setting a new one
        if (pitchCoroutine != null)
        {
            StopCoroutine(pitchCoroutine);
        }

        // if duration is a very small number just set pitch directly
        // avoids potential division by 0
        if (duration <= Mathf.Epsilon && duration >= -Mathf.Epsilon)
        {
            SetPitch(target);
        }
        else
        {
            // assign transition to variable, then start the coroutine
            pitchCoroutine = PitchTransitionCoroutine(target, duration);
            StartCoroutine(pitchCoroutine);
        }
    }


    // change volume to target frequency over duration seconds
    public void VolumeTransition(float target, float duration)
    {
        // set targetPitch variable to allow access to desired pitch to any object modifying it while coroutine is active
        targetVolume = target;

        // stop any volume transitions before starting a new one
        if (volumeCoroutine != null)
        {
            StopCoroutine(volumeCoroutine);
        }

        // if duration is a very small number just set volume directly
        // avoids potential division by 0
        if (duration <= Mathf.Epsilon && duration > 0)
        {
            SetVolume(target);
        }
        else
        {
            // assign transition to variable, then start the coroutine
            volumeCoroutine = VolumeTransitionCoroutine(target, duration);
            StartCoroutine(volumeCoroutine);
        }
    }


    // Coroutine for transitioning the pitch, run by calling PitchTransition
    IEnumerator PitchTransitionCoroutine(float target, float duration)
    {
        float from = audio.pitch;
        float invDuration = 1.0f / duration;

        // the "counter" variable to track position within Lerp
        float currStep = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(audio.pitch - target) > 0.0f)
        {
            audio.pitch = Mathf.Lerp(from, target, currStep);
            currStep += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }


    // Coroutine for transitioning volume, run by calling VolumeTransition
    IEnumerator VolumeTransitionCoroutine(float target, float duration)
    {
        float from = audio.volume;
        float invDuration = 1.0f / duration;

        // the "counter" variable to track position within Lerp
        float currStep = Time.unscaledDeltaTime * invDuration;

        while (Mathf.Abs(audio.volume - target) > 0.0f)
        {
            audio.volume = Mathf.Lerp(from, target, currStep);
            currStep += Time.unscaledDeltaTime * invDuration;
            yield return null;
        }
    }
}
