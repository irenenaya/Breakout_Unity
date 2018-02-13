﻿using UnityEngine;


public static class InputHandle
{
	public static float Horizontal
	{
		get { return Input.GetAxis("Horizontal"); }
		private set { }
	}


	public static float Vertical
	{
		get { return Input.GetAxis("Vertical"); }
		private set { }
	}

	public static bool Up 
	{
		get { return Input.GetKeyDown (KeyCode.UpArrow); }
		private set { }
	}

	public static bool Down 
	{
		get { return Input.GetKeyDown (KeyCode.DownArrow); }
		private set { }
	}


	public static bool Enter
	{
		get { return Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter); }
		private set { }
	}


    public static bool Pause
    {
        get { return Input.GetKey(KeyCode.Space); }
        private set { }
    }
}