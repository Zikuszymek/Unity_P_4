using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchSpeed;
    public bool inPlay = false;

    private Vector3 startPosition;
    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 nullVelocity = new Vector3(0,0,0);
    
	void Start ()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidBody.useGravity = false;
    }

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        audioSource.Play();
    }

    public void Reset()
    {
        rigidBody.useGravity = false;
        inPlay = false;
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = nullVelocity;
        rigidBody.angularVelocity = nullVelocity;
        Debug.Log("Reseting ball");
    }

    // Update is called once per frame
    void Update () {
		
	}


}
