using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private Vector3 dragStart, dragEnd, mousePosition;
    private bool ballinPlay;

    public GameObject mark;
    public GameObject arrow;
    public GameObject point;

    private GameObject[] pointsToArrow;
    private GameObject startMark, arrowMark, pointLine;

    private bool dragStarted = false;

	void Start () {
        ball = GetComponent<Ball>();
	}

    private void Update()
    {
        if (dragStarted && !ball.inPlay)
        {
            drawArrow();
            drawLine();
        }
    }

    private void drawLine()
    {
        InstaintiatePointsIfNull();
        RectTransform imageRectTransform = pointLine.GetComponent<RectTransform>();
        mousePosition = Input.mousePosition;
        Vector3 offset = mousePosition - startMark.transform.position;
        imageRectTransform.sizeDelta = new Vector2(offset.magnitude, 2f);
        imageRectTransform.pivot = new Vector2(0, 0.5f);
        imageRectTransform.position = startMark.transform.position;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        imageRectTransform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void InstaintiatePointsIfNull()
    {
        if (!pointLine)
        {
            pointLine = Instantiate(point, transform.position, Quaternion.identity);
            pointLine.transform.parent = FindObjectOfType<Canvas>().transform;
        }
    }

    private void drawArrow()
    {
        InstantiateArrowIfNull();
        mousePosition = Input.mousePosition;
        arrowMark.transform.position = mousePosition;
        arrowMark.transform.rotation = getQuatertionForArrow();
    }

    private Quaternion getQuatertionForArrow()
    {
        Vector3 direction = arrowMark.transform.position - startMark.transform.position;
        return Quaternion.LookRotation(Vector3.forward, direction);
    }

    private void InstantiateArrowIfNull()
    {
        if (!arrowMark)
        {
            arrowMark = Instantiate(arrow, transform.position, Quaternion.identity);
            arrowMark.transform.parent = FindObjectOfType<Canvas>().transform;
        }
    }

    public void MoveStart(float pixels)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + pixels, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }
	
    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStarted = true;
            dragStart = Input.mousePosition;
            startMark = Instantiate(mark, dragStart, Quaternion.identity);
            startMark.transform.parent = FindObjectOfType<Canvas>().transform;
        }
    }

    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;

            float launchSpeedX = (dragEnd.x - dragStart.x) * 2;
            float launchSpeedZ = (dragEnd.y - dragStart.y) * 2;

            Vector3 velocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
            ball.Launch(velocity);
            ball.inPlay = true;

            dragStarted = false;
            Destroy(startMark);
            Destroy(arrowMark);
            Destroy(pointLine);
        }
    }
}
