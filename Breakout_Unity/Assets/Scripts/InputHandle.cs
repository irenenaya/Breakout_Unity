using UnityEngine;


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

	public static bool Left
	{
		get { return Input.GetKeyDown (KeyCode.LeftArrow);}
		private set { }
	}

	public static bool Right 
	{
		get { return Input.GetKeyDown (KeyCode.RightArrow);}
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
		get { return Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter); }
		private set { }
	}


    public static bool Pause
    {
        get { return Input.GetKeyDown(KeyCode.Space); }
        private set { }
    }
}