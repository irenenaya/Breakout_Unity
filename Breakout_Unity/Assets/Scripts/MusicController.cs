using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource music;
    bool lerping = false;

	void Awake()
    {
        music = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
        // if (InputHandle.Pause) music.pitch *= 0.95f;
        if (lerping || Input.GetKeyDown(KeyCode.Tab))
        {
            lerping = true;
            //TransitionPitch(1.0f, 0.0f, 2f);
            music.pitch = Mathf.Lerp(1f, 0f, Time.unscaledDeltaTime);

        }
    }
}
