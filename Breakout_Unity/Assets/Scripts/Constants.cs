using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SceneConstants {
	public const string PADDLESELECT = "PaddleSelectScene";
	public const string PLAY = "PlayScene";
	public const string START = "StartScene";
	public const float BALLY = -3.2f;
	}

static public class PowerUpConstants {
	public const string KEY = "Key";
	public const string GREEN_X = "Green_X";
	public const string RED_X = "Red_X";
	public const string EXTRA_LIFE = "Extra_Life";
	public const string ENLARGE_PADDLE = "Enlarge_Paddle";
	public const string SHRINK_PADDLE = "Shrink_Paddle";

}

static public class GameParameters {
	public static int paddleIndex = 0;
	public static int level = 1;
	public static int score = 0;
}