using UnityEngine;


public static class InputHandle
{
	public static float Horizontal
	{
		get { return Input.GetAxis("horizontal"); }
		private set { }
	}


	public static float Vertical
	{
		get { return Input.GetAxis("vertical"); }
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