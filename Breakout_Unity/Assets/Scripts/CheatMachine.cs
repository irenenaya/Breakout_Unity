using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatMachine : MonoBehaviour {
    public string[] slowMusic;
    public KeyCode triggerWith;
    public float maxTime;

    float startTime;
    bool gettingInput;

    string cheatCode;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update()
    {
        if (Input.GetKeyUp(triggerWith))
        {
            startTime = Time.time;
            gettingInput = true;
            cheatCode = "";
        }

        if (Time.time - startTime > maxTime)
        {
            gettingInput = false;
            cheatCode = "";
        }

        if (gettingInput)
        {
            cheatCode += Input.inputString;

			CompareCode (cheatCode, slowMusic);
        }
	}

	void CompareCode(string cheat, string[] codes)
	{
		foreach (var code in codes)
		{
			if (cheat == code)
			{
				GameObject.Find("BackgroundMusic").GetComponent<MusicController>().PitchTransition(0.5f, 2.0f);
			}
		}
	}
}
