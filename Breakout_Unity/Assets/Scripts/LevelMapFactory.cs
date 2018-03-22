using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures;

public static class LevelMapFactory  {

	//Random rnd = new Random ();
	const int MAX_TIER = 19;
	const int TIER_MULT = 10;
	const int MAX_ROWS = 6;
	const int COLS = 11;

	static public LevelMap Generate(int level) {
		// Sum of all Tiers == level * a mutuplajr
		int soat = level * TIER_MULT;
		// minimum Tier for this level. For now, level / 2
		int minTier = (int)Mathf.Ceil(level / 2.0f);
		// maximum Tier for this level. Either the current level or MAX_TIER if level is >
		int maxTier = Mathf.Min (level, MAX_TIER);
		// minimum possible number of bricks so we can fit all the soat points. 
		int minBricks = soat / maxTier + 1;

		int maxBricks = soat / minTier;

		// minimum possible number of rows to fit at least the minimum of bricks
		int minRows = (int)Mathf.Ceil((float)minBricks / COLS);

		// number of rows: It's a random number between the minimum and maximum for this level. 
		int rows = Random.Range (minRows, Mathf.Min (level, MAX_ROWS));
		// actual amount of bricks to fit. Random between the minimum and the total size of the grid with 
		// this amount of rows. 
		int bricks = Random.Range ((minBricks + Mathf.Min (maxBricks, rows * COLS)) / 2, Mathf.Min (maxBricks, rows * COLS));

		LevelMap lm = new LevelMap (rows, COLS);
		int remainingPoints = lm.InitMap (minTier, bricks, soat);
		lm.completeMap (remainingPoints, maxTier);
		return lm;
	}

	public class LevelMap
	{
		public int[][] bricks { get; private set;}
        public int[][] powerups { get; private set; }
        int _rows;
		int _cols;

		public LevelMap(int rows, int cols)
		{
			_rows = rows;
			_cols = cols;
			bricks = new int[rows][];
            powerups = new int[rows][];
			for (int i = 0; i < rows; ++i)
			{
				bricks[i] = new int[cols];
                powerups[i] = new int[cols];
			}
		}
		// initialize map with minTier value at random locations. It initializes the map mirrored across the Y
		// it returns the remaining soat points to be used in the next function
		public int InitMap(int value, int bricks, int soat)
		{
			while(bricks > 0) {
				
				// gets random value for row and the left half of the columns
				int row = Random.Range(0, _rows);
				int col = Random.Range(0, _cols/2 +1);
				// if this cell hasn't been initialized set the value to it and to its mirror (via a 
				// very properly named function :p )
				if (this.bricks[row][col] == 0){
					this.bricks [row] [col] = value;
					--bricks;
					soat -= value;
					int col2 = Frodo(col);
					if (col2 != col) {
						this.bricks[row] [col2] = value;
						--bricks;
						soat -= value;
					}
				}
			}
			return soat;
		}
		// completes Map by adding 1 point to each already filled cell as long as we don't reach maxTier
		public void completeMap(int soat, int maxTier)
		{
			while(soat > 0) {
				int row = Random.Range(0, _rows);
				int col = Random.Range(0, _cols/2 +1);
				if (bricks[row][col] !=0 && bricks[row][col] < maxTier) {
					++bricks [row] [col];
					++bricks [row] [Frodo (col)];
					soat -= 2;
				}
			}
		}
		// Properly named function to return mirrored index. 
		int Frodo (int coll)
		{
			return (COLS / 2 - coll) + COLS / 2;
		}


        public void PlacePowerups(int n)
        {
            // int[] powerUps = CreatePowerups(n, 0, 5);
            int nrBricks = CountBricks();

            int[] brickIndices = new int[nrBricks];
            for (int i = 0; i < nrBricks; ++i)
            {
                brickIndices[i] = i;
            }

            BinaryHeap<int> powerupBricks = new BinaryHeap<int>();
            powerupBricks.Push(RandomSelectFrom(brickIndices, n));

            int counter = 0;
            for (int i = 0; i < _rows; ++i)
            {
                for (int j = 0; j < _cols; ++j)
                {
                    if (bricks[i][j] != 0)
                    {
                        if (powerupBricks.Peek() == counter)
                        {
                            bricks[i][j] = Random.Range(1, 5);
                        }
                        ++counter;
                    }
                }
            }
        }

        int[] CreatePowerups(int n, int minVal, int maxVal)
        {
            int[] ret = new int[n];
            for (int i = 0; i < n; ++i)
            {
                ret[i] = Random.Range(minVal, maxVal);
            }
            return ret;
        }

        int CountBricks()
        {
            int ret = 0;
            for (int i = 0; i < _rows; ++i)
            {
                for (int j = 0; j < _cols; ++j)
                {
                    if (bricks[i][j] != 0) ++ret;
                }
            }
            return ret;
        }

        int[] RandomSelectFrom(int[] data, int n)
        {
            List<int> indices = new List<int>(n);
            for (int i = 0; i < data.Length; ++i)
            {
                indices.Add(i);
            }

            int[] ret = new int[n];
            for (int i = 0; i < n; ++i)
            {
                int x = Random.Range(0, indices.Count);
                ret[i] = data[indices[x]];
                indices.Remove(indices[x]);
            }

            return ret;
        }

	}
}
