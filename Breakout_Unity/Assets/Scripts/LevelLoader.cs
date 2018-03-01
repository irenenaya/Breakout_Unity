using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Brick brick;
	public Paddle paddle;
	public Ball ball;
    public float screenWidth;
    public float screenHeight;
    
	Animator stateMachine;
	// Use this for initialization
	void Start()
    {
		stateMachine = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Animator> ();
		CreateMap ();
		Instantiate (paddle, new Vector2 (0, -4), Quaternion.identity);
		Instantiate (ball, new Vector2 (0, SceneConstants.BALLY), Quaternion.identity);
	}
    

    Vector2 ObjectSize(GameObject obj)
    {
        BoxCollider2D collider = obj.GetComponent<BoxCollider2D>();
        float w = collider.size.x * obj.transform.localScale.x;
        float h = collider.size.y * obj.transform.localScale.y;

        return new Vector2(w, h);
    }

    Vector2 GridSize(Vector2 brickSize, int rows, int cols)
    {
        return new Vector2(brickSize.x * cols, brickSize.y * rows);
    }

    void CreateBrick(Vector2 coords, int tier)
    {
        Brick brickInstance = Instantiate(brick);
        brickInstance.transform.SetPositionAndRotation(coords, new Quaternion());
        brickInstance.SetTier(tier);
    }

    

	void CreateMap()
    {
        Vector2 brickSize = ObjectSize(brick.gameObject);

		int numRows = Random.Range(1, Mathf.Min(GameParameters.level + 1,  6));
        int numCols = Random.Range(7, 14);
		int keyBrick = Random.Range (0, numCols + numRows);

        numCols = numCols % 2 == 0 ? numCols + 1 : numCols;

        // find the size of the grid
        Vector2 gridSize = GridSize(brickSize, numRows, numCols);

        // find top left corner of our screen
		// left is negative, top is positive. I flipped the signs here
        Vector2 topLeft = new Vector2(-screenWidth / 2, screenHeight / 2);
        
        // find offset between the screen edges and the grid
		// Added offsetY. The divisor can be changed depending on how high up we want the bricks
		// 8 looks ok but we can change it
        float offsetX = (screenWidth - gridSize.x) / 2.0f;
		float offsetY = screenHeight / 9.0f;
        
		int numBricks = 0;
        
		for (int i = 0; i < numRows; ++i)
        {
			int skip = Random.Range (1, 3);
			int brickColors = Random.Range (0, 4);
            for (int j = 0; j < numCols; j = j + skip)
            {
				// added topLeft.x and topLeft.y to the equation. 
				// subtracted for the Y because each brick is at a lower y 
				float x = topLeft.x + offsetX + brickSize.x / 2 + brickSize.x * j;
				float y = topLeft.y - offsetY - brickSize.y / 2 - brickSize.y * i;
				if (i + j == keyBrick) {
					CreateBrick (new Vector2 (x, y), 20);
				} else {
					CreateBrick (new Vector2 (x, y), brickColors * GameParameters.level + (i * (skip % 2)));
				}
				++numBricks;
            }
        }

		stateMachine.SetInteger ("Bricks", numBricks);

    }
}
