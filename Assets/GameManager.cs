using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<int> bowls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;
	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }
	
	public void Bowl(int pinFalls)
    {
        bowls.Add(pinFalls);
        ScoreMaster.Action nextAction = ScoreMaster.NextAction(bowls);
        pinSetter.performAction(nextAction);

        try
        {
            scoreDisplay.FillRollCard(bowls);
            scoreDisplay.FillFrames(ActionMaster.ScoreCumulatiove(bowls));
        } catch
        {
            Debug.LogWarning("Error help, pls");
        }
        ball.Reset();
    }
}
