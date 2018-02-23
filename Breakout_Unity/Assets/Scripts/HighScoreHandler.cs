using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using DataStructures;

public class HighScoreHandler : MonoBehaviour
{
    public string localPath = "Savedata";
    public string fileName = "highscores.txt";

    public ScoreboardEntry[] DisplayData { get; private set; }

    BinaryHeap<ScoreboardEntry> priorityQueue = new BinaryHeap<ScoreboardEntry>();


	// Use this for initialization
	void Start()
    {
        LoadData(localPath, fileName);
        DisplayData = priorityQueue.Peek(10);
    }


    /**
     * Loads data from path/filename into priorityQueue
     * Assumes single word followed by a single integer on each line of the file
     */
    void LoadData(string path, string filename)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            return; // if we're here the directory didn't exist so the file certainly won't
        }
        
        if (!File.Exists(path + '/' + filename))
        {
            return;
        }

        // read the file into a string array
        string[] lines = System.IO.File.ReadAllLines(path + '/' + filename);

        // fill priority queue with scoreboard entries from each line of the file
        foreach (string line in lines)
        {
            string[] nameScore = line.Split();
            priorityQueue.Push(new ScoreboardEntry(nameScore[0], int.Parse(nameScore[1])));
        }   
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
