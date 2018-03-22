using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMachine : MonoBehaviour
{
    public KeyCode triggerWith;
    public float maxTime;
    public string[] slowMusic;
    public string normalSpeedMusic;
    public string silence;
    public string unsilence;
    public string softAndSlow;
    public MusicController music;

    float initialMusicVolume;
    
    float startTime;
    bool gettingInput;

    string enteredCode;

	// Use this for initialization
	void Start ()
    {
        initialMusicVolume = music.volume;
		
	}
	
	// Update is called once per frame
	void Update()
    {
        // if (Input.GetKeyDown(KeyCode.KeypadMultiply)) music.volume = 0.0f;
        if (Input.GetKeyUp(triggerWith))
        {
            startTime = Time.time;
            gettingInput = true;
            enteredCode = "";
        }

        if (Time.time - startTime > maxTime)
        {
            gettingInput = false;
            enteredCode = "";
        }

        if (gettingInput)
        {
            enteredCode += Input.inputString;

			if (CompareCode(enteredCode, slowMusic)) music.PitchTransition(0.5f, 2.0f);
            else if (CompareCode(enteredCode, normalSpeedMusic)) music.PitchTransition(1.0f, 2.0f);
            else if (CompareCode(enteredCode, silence)) music.VolumeTransition(0.0f, 2.0f);
            else if (CompareCode(enteredCode, unsilence)) music.VolumeTransition(initialMusicVolume, 2.0f);
            else if (CompareCode(enteredCode, softAndSlow))
            {
                music.PitchTransition(0.75f, 2.0f);
                music.VolumeTransition(0.5f, 2.0f);
            }
			 
        }
	}

	bool CompareCode(string cheat, string[] codes)
	{
		foreach (var code in codes)
		{
			if (cheat == code)
			{
                return true;
			}
		}

        return false;
	}

    bool CompareCode(string cheat, string code)
    {
        return cheat == code;
    }
}
