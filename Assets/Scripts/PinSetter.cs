using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour { 

    public GameObject pinSet;

    private Animator pinAnimator;
    private PinCounter pinCounter;

    private void Start()
    {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        pinAnimator = GetComponent<Animator>();
    }

    public void performAction(ScoreMaster.Action action)
    {
        switch (action)
        {
            case ScoreMaster.Action.EndGame:
                pinAnimator.SetTrigger("resetTrigger");
                break;
            case ScoreMaster.Action.EndTurn:
                pinAnimator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ScoreMaster.Action.Reset:
                pinAnimator.SetTrigger("resetTrigger");
                pinCounter.Reset();
                break;
            case ScoreMaster.Action.Tidy:
                pinAnimator.SetTrigger("tidyTrigger");
                break;
        }
    }

    void RaisePins()
    {
        Debug.Log("Rising pins");
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.RaiseIfStanding();
        }
    }


    void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.LowerIfStanding();
        }
    }

    public void RenewPins()
    {
        Debug.Log("Renew pins");
        Instantiate(pinSet, new Vector3(0, 0, 1857), Quaternion.identity);
    }
}
