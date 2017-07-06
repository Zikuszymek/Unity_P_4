using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour {

    public Ball ball;

    private Vector3 cameraOffset;

	void Start () {
        cameraOffset = transform.position - ball.transform.position;
	}

    void Update()
    {
        if (ball.transform.position.z <= 1700f)
        {
            FollowBall();
        }
    }

    public void FollowBall()
    {
        transform.position = ball.transform.position + cameraOffset;
    }
}
