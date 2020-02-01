using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRend : MonoBehaviour
{
    [SerializeField] private float triggerSpeed = 15f;
    private float movementSpeed;


    private void update()
    {
    	movementSpeed = gameObject.transform.parent.GetComponent<Rigidbody>().velocity.magnitude;

    	//GetComponent<Rigidbody>.velocity;

    	if (movementSpeed >= triggerSpeed)
    	{
    		GetComponent<TrailRenderer>().enabled = true;
    	}
    }
}
