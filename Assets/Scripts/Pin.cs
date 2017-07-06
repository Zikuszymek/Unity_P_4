using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    public float standingThreshold = 50f;
    private float riseDistance = 80f;
    private Rigidbody pinRigidbody;

    // Use this for initialization
    void Start () {
        pinRigidbody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        IsStanding();
    }

    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;
        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if (tiltInX < standingThreshold && tiltInZ < standingThreshold)
            return true;
        return false;
    }

    public void RaiseIfStanding()
    {
            if (IsStanding())
            {
                pinRigidbody.useGravity = false;
                transform.Translate(new Vector3(0, riseDistance, 0), Space.World);
                transform.rotation = Quaternion.Euler(270f, 0, 0);
            }
       
    }


    public void LowerIfStanding()
    {
            if (IsStanding())
            {
                pinRigidbody.useGravity = true;
                transform.Translate(new Vector3(0, -riseDistance, 0), Space.World);
            }
    }
}
