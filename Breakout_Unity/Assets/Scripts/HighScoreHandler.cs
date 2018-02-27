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
        LoadData();
        int displayAmount = priorityQueue.Size < 10 ? priorityQueue.Size : 10;
        DisplayData = priorityQueue.Peek(displayAmount);
    }


    /**
     * Loads data from localPath/fileName into priorityQueue
     * Assumes single word followed by a single integer on each line of the file
     */
    public void LoadData()
    {
        if (!Directory.Exists(localPath))
        {
            // if we're here the directory didn't exist so the file certainly won't
            return; 
        }
        
        if (!File.Exists(localPath + '/' + fileName))
        {
            return;
        }

        // read the file into a string array
        string[] lines = System.IO.File.ReadAllLines(localPath + '/' + fileName);

        // fill priority queue with scoreboard entries from each line of the file
        foreach (string line in lines)
        {
            string[] nameScore = line.Split();
            priorityQueue.Push(new ScoreboardEntry(nameScore[0], int.Parse(nameScore[1])));
        }


    }


    public void SaveData()
    {
        if (!Directory.Exists(localPath))
        {
            Directory.CreateDirectory(localPath);
        }

        /*
        if (File.Exists(localPath + '/' + fileName))
        {
            File.Delete(localPath + '/' + fileName);
        }
        */
        // File.Create(localPath + '/' + fileName);

        // TODO perhaps use PopAll instead?
        ScoreboardEntry[] scores = priorityQueue.PeekAll();
        string[] data = new string[scores.Length];

        for (int i = 0; i < scores.Length; ++i)
        {
            data[i] = scores[i].name + ' ' + scores[i].score;
        }

        File.WriteAllLines(localPath + '/' + fileName, data);
    }


    public void AddScore(string name, int score)
    {
        priorityQueue.Push(new ScoreboardEntry(name, score));
        int displayAmount = priorityQueue.Size < 10 ? priorityQueue.Size : 10;
		// changed condition. Otherwise, it doesn't update DisplayData when size < 10
        if (priorityQueue.Size < 10 || score > DisplayData[9].score)
        {
            DisplayData = priorityQueue.Peek(displayAmount);
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
            //return score.CompareTo(other.score);
			// this is the way to get the pq sort highest to lowest
			return other.score.CompareTo(score);
        }
    }
}
