using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class SceneConstants {
    public const string PADDLESELECT = "PaddleSelectScene";
    public const string PLAY = "PlayScene";
    public const string START = "StartScene";
    public const string GAME = "GameScene";
    public const float BALLY = -3.2f;
    }

enum PowerUpConstants { EXTRA_LIFE, ENLARGE_PADDLE, SHRINK_PADDLE,EXTRA_BALL ,KEY  } ;


static public class GameParameters {
    public static int paddleIndex = 0;
    public static int level = 1;
    public static int score = 0;
}