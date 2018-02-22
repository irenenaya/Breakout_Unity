using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataStructures;

public class HighScoreHandler : MonoBehaviour
{
    BinaryHeap<ScoreboardEntry> data = new BinaryHeap<ScoreboardEntry>();

	// Use this for initialization
	void Start()
    {

    }

    // Update is called once per frame
    void Update () {
		
	}

    public class ScoreboardEntry : IComparable
    {
        public string name;
        public int score;

        public ScoreboardEntry(string n, int s)
        {
            name = n;
            score = s;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("ScoreboardEntry.CompareTo argument is null!");
            ScoreboardEntry other = obj as ScoreboardEntry;
            if (other == null)
                throw new ArgumentException("ScoreboardEntry.CompareTo - argument not ScoreboardEntry!");
            return score.CompareTo(other.score);
        }
    }
}
