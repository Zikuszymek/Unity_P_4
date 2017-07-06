using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ScoreMasterTests {

    private List<int> pinFalls;
    private ScoreMaster.Action endTurn;
    private ScoreMaster.Action tidy;
    private ScoreMaster.Action reset;
    private ScoreMaster.Action endGame;

    [SetUp]
    public void Setup(){
        pinFalls = new List<int>();
        endTurn = ScoreMaster.Action.EndTurn;
        tidy = ScoreMaster.Action.Tidy;
        reset = ScoreMaster.Action.Reset;
        endGame = ScoreMaster.Action.EndGame;
    }

    [Test]
    public void PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01OneStrikeReturnEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ScoreMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ScoreMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03Bowl28SpareReturnsEntTurn()
    {
        int[] rolls = { 2, 8 };
        pinFalls.Add(8);
        Assert.AreEqual(endTurn, ScoreMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T04CheckResetAtLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
        Assert.AreEqual(reset, ScoreMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T05heckResetAtLastFrame()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 ,1,9};
        Assert.AreEqual(reset, ScoreMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T06EndGame()
    {
        int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
        Assert.AreEqual(endGame, ScoreMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07EndGameAt20Bowl()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        Assert.AreEqual(endGame, ScoreMaster.NextAction(rolls.ToList()));
    }

    [Test]
    public void T07EndGameSpecialTest()
    {
        int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
        Assert.AreEqual(tidy, ScoreMaster.NextAction(rolls.ToList()));
    }

}
