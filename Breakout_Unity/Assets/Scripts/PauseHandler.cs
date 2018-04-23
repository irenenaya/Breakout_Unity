using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    Animator stateMachine;

    bool paused = false;

    // Use this for initialization
    void Awake()
    {
        stateMachine = GameObject.FindGameObjectWithTag("GameController").GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (InputHandle.Pause)
        {
            paused = !paused;
        }

        if (paused) Time.timeScale = 0.0f;
        else Time.timeScale = 1.0f;
    }
}
