﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class ActionMasterTest
{

    [Test]
    public void T01Bowl23()
    {
        int[] rolls = { 2, 3 };
        int[] frames = { 5 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T02Bowl234()
    {
        int[] rolls = { 2, 3 ,4};
        int[] frames = { 5 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T03Bowl2345()
    {
        int[] rolls = { 2, 3, 4, 5 };
        int[] frames = { 5 , 9};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T04Bowl23456()
    {
        int[] rolls = { 2, 3, 4, 5, 6 };
        int[] frames = { 5, 9 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T05Bowl234561()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T06Bowl2345612()
    {
        int[] rolls = { 2, 3, 4, 5, 6, 1, 2 };
        int[] frames = { 5, 9, 7 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T07BowlX1()
    {
        int[] rolls = { 10, 1 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T07Bowl19()
    {
        int[] rolls = { 1 ,9 };
        int[] frames = { };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T07Bowl123455()
    {
        int[] rolls = { 1, 2, 3, 4, 5, 5 };
        int[] frames = { 3, 7};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T10SpareBonus()
    {
        int[] rolls = { 1, 2, 3, 4, 5, 5 ,3 ,3};
        int[] frames = { 3, 7 , 13, 6};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T11SpareBonus()
    {
        int[] rolls = { 1,2,3,5,5,5,3,3,7,1,9,1,6 };
        int[] frames = { 3, 8, 13, 6 ,8, 16};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T12StrikeBonus()
    {
        int[] rolls = { 10,3,4 };
        int[] frames = { 17,7};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T13StrikeBonus3()
    {
        int[] rolls = { 1,2,3,4,5,4,3,2,10,1,3,3,4 };
        int[] frames = { 3,7,9,5,14,4,7};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T14MultiStrike3()
    {
        int[] rolls = { 10, 10, 2,3, 10,5,3 };
        int[] frames = {22, 15, 5,18,8 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T15MultiStrike3()
    {
        int[] rolls = { 10, 10, 2,3 };
        int[] frames = { 22, 15, 5 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T16TestGutterGame()
    {
        int[] rolls = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] frames = {0,0,0,0,0,0,0,0,0,0 };
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    [Test]
    public void T17AllStrikes()
    {
        int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        int[] totalS = { 30, 60, 90, 120, 150, 180, 210, 240, 270, 300 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    [Test]
    public void T19StrikeBOnus()
    {
        int[] rolls = {5,5,3 };
        int[] frames = { 13};
        Assert.AreEqual(frames.ToList(), ActionMaster.ScoreFrames(rolls.ToList()));
    }

    // http://slocums.homestead.com/gamescore.html
    [Test]
    [Category("Verification")]
    public void TG02GoldenCopyA()
    {
        int[] rolls = { 10, 7, 3, 9, 0, 10, 0, 8, 8, 2, 0, 6, 10, 10, 10, 8, 1 };
        int[] totalS = { 20, 39, 48, 66, 74, 84, 90, 120, 148, 167 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB1of3()
    {
        int[] rolls = { 10, 9, 1, 9, 1, 9, 1, 9, 1, 7, 0, 9, 0, 10, 8, 2, 8, 2, 10 };
        int[] totalS = { 20, 39, 58, 77, 94, 101, 110, 130, 148, 168 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB2of3()
    {
        int[] rolls = { 8, 2, 8, 1, 9, 1, 7, 1, 8, 2, 9, 1, 9, 1, 10, 10, 7, 1 };
        int[] totalS = { 18, 27, 44, 52, 71, 90, 110, 137, 155, 163 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    //http://guttertoglory.com/wp-content/uploads/2011/11/score-2011_11_28.png
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyB3of3()
    {
        int[] rolls = { 10, 10, 9, 0, 10, 7, 3, 10, 8, 1, 6, 3, 6, 2, 9, 1, 10 };
        int[] totalS = { 29, 48, 57, 77, 97, 116, 125, 134, 142, 162 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyC1of3()
    {
        int[] rolls = { 7, 2, 10, 10, 10, 10, 7, 3, 10, 10, 9, 1, 10, 10, 9 };
        int[] totalS = { 9, 39, 69, 96, 116, 136, 165, 185, 205, 234 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }

    // http://brownswick.com/wp-content/uploads/2012/06/OpenBowlingScores-6-12-12.jpg
    [Category("Verification")]
    [Test]
    public void TG03GoldenCopyC2of3()
    {
        int[] rolls = { 10, 10, 10, 10, 9, 0, 10, 10, 10, 10, 10, 9, 1 };
        int[] totalS = { 30, 60, 89, 108, 117, 147, 177, 207, 236, 256 };
        Assert.AreEqual(totalS.ToList(), ActionMaster.ScoreCumulatiove(rolls.ToList()));
    }
}