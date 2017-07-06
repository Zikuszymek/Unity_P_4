using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerExit(Collider other)
    {
        GameObject thingHitted = other.gameObject;
        if (thingHitted.GetComponent<Pin>())
        {
            Destroy(thingHitted);
        }
    }

}
