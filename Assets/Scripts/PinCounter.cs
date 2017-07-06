using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;

    public bool ballOutOfPlay = false;
    private bool ballEnteredBox = false;
    private float lastChangeTime;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        standingDisplay.color = Color.green;
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    public void setToRed()
    {

    }
	
	// Update is called once per frame
	void Update () {
        standingDisplay.text = CountStanding().ToString();
        if (ballOutOfPlay)
        {
            standingDisplay.color = Color.red;
            UpdateStandingCountAndSettle();
        }
    }

    int CountStanding()
    {
        int standing = 0;
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }
        return standing;
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }

    void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();
        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
        }

        float settleTime = 3f;
        if (Time.time - lastChangeTime > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;
        ballEnteredBox = false;
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }
}
