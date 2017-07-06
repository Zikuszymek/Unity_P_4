using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public static class ActionMaster{

    public static List<int> ScoreCumulatiove(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;
        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    public static List<int> ScoreFrames(List<int> rollsList)
    {
        List<int> frameList = new List<int>();
        int bowlCount = rollsList.Count;
        bool frameEnd = true;

        for (int i = 0; i < bowlCount; i++)
        {
            if (rollsList[i] < 0 || rollsList[i] > 10) throw new UnityException("Invalid number of pins");
            if (frameList.Count == 10) break; //we have all frames

            frameEnd = !frameEnd;

            if (frameEnd)
            {
                if (rollsList[i - 1] + rollsList[i] < 10)
                {
                    frameList.Add(rollsList[i - 1] + rollsList[i]); //frame ends without strike or spare
                }
                else if (bowlCount > i + 1)
                {
                    frameList.Add(rollsList[i - 1] + rollsList[i] + rollsList[i + 1]); //spare
                }
            }

            else if (rollsList[i] == 10)
            { //strike
                if (bowlCount > i + 2) frameList.Add(10 + rollsList[i + 1] + rollsList[i + 2]);
                frameEnd = true;
            }
        }
        return frameList;
    }
}