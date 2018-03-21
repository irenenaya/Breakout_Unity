using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		public int[][] map { get; private set;}
		int _rows;
		int _cols;

		public LevelMap(int rows, int cols)
		{
			_rows = rows;
			_cols = cols;
			map = new int[rows][];
			for (int i = 0; i < rows; ++i)
			{
				map[i] = new int[cols];
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
				if (map[row][col] == 0){
					map [row] [col] = value;
					--bricks;
					soat -= value;
					int col2 = Frodo (col);
					if (col2 != col) {
						map[row] [col2] = value;
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
				if (map[row][col] !=0 && map[row][col] < maxTier) {
					++map [row] [col];
					++map [row] [Frodo (col)];
					soat -= 2;
				}
			}
		}
		// Properly named function to return mirrored index. 
		int Frodo (int coll)
		{
			return (COLS / 2 - coll) + COLS / 2;
		}
	}
	
}
