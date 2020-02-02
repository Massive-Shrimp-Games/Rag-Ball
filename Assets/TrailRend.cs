using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRend : MonoBehaviour
{
    [SerializeField] private float triggerSpeed = 20f;
    [SerializeField] private float movementSpeed;
    public GameObject Trail;

    private void update()
    {
    	movementSpeed = gameObject.transform.parent.GetComponent<Rigidbody>().velocity.magnitude;
        Debug.Log("My speed is" + movementSpeed);
    	
    	if (movementSpeed >= triggerSpeed)
    	{
            Trail.SetActive(true);
        }
        else
        {
            Trail.SetActive(false);
        }
    }
}
