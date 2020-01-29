

// IMPORTS
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ABOUT
// Attach to an object and select another object in the editor to set the coordinates of this object to that object every frame


public class followObject : MonoBehaviour
{

	// REFERENCES
	// https://docs.unity3d.com/ScriptReference/GameObject-transform.html


	// VARIABLES
	// Track all the Transforms and Objects
	[SerializeField] private GameObject target;			// What we want to follow; Set from editor
	private Transform targetTransform;	// What we are going to follow
	private Transform thisTransform;	// What we are moving


	// START
	// Find the Transforms of al the Objects
	private void Start()
	{
		thisTransform = gameObject.transform;
		targetTransform = target.transform;
	}

	// UPDATE
	// Move this Object to the Target's position
    private void Update()
    {
        thisTransform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z);
    }
}
