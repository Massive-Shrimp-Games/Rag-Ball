using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Activates and Deactivates a List of GameObjects
/// see: https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
/// see: https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html
/// see: https://answers.unity.com/questions/13356/how-can-i-assign-materials-using-c-code.html?_ga=2.257422796.611847350.1580512480-1535617163.1580512480
/// see: https://youtu.be/dJB07ZSiW7k (Scripting: Change Material of an Object | Unity Tutorial)
/// </summary>
public class LeverToggle : MonoBehaviour
{

    // Activate the Lever
    [SerializeField] private float triggerSpeedThreshold = 5f;          // Speed which we trigger on
    private float incomingSpeed;                                        // Speed of Object that could trigger us


    // Message the targets
    public List<GameObject> targetObjects = new List<GameObject>();     // Where we store objects to activate/deactivate


    // Change the appearance of the Lever
    [SerializeField] private List<Material> materials = new List<Material>();       // Holds On and Off Material
    [SerializeField] public bool leverState = true;                                 // Controls position of Lever and activates children -- can be set in script
    [SerializeField] private MeshRenderer leverRenderer;                            // Where we set the new material
    [SerializeField] private Transform leverTransform;                              // Control position of lever
    [SerializeField] private int cooldown = 1;                                      // The cooldown between allowed lever-collisions
    private bool canToggle = true;                                                  // The boolean which lets us know we can be triggered

    /// <summary>
    /// Sets the initial state of the children and the appearance
    /// </summary>
    private void Start()
    {
        leverTransform = this.transform.parent.transform;
        leverRenderer = GameObject.Find("InnerCylinder").GetComponent<MeshRenderer>();
        
        // If we start ON
        if(leverState)
        {
            // Set All Children to ON
            //TriggerActivate();

            // Set the Appearance
            leverRenderer.sharedMaterial = materials[0];
        }
        // If we start OFF
        else
        {
            // Set All Childen to OFF
            TriggerActivate();
            
            // Set the Appearance
            leverRenderer.sharedMaterial = materials[1];
        }
    }

    IEnumerator WaitingCoroutine()
    {
        //yield on a new YieldInstruction that waits for "cooldown" seconds.
        yield return new WaitForSeconds(cooldown);
        canToggle = true;
        //Debug.Log("reset cooldown");
    }

    //The function is setup with the var col_counter so that only 1 discrete collision
    //with the lever occurs
    private void OnCollisionEnter (Collision collision)
    {
        //This code will run on FIRST COLLISION
        if(canToggle)
        {
            incomingSpeed = collision.relativeVelocity.magnitude;
            if (incomingSpeed >= triggerSpeedThreshold)
            {
                StartCoroutine(WaitingCoroutine());
                leverState = !leverState;
                TriggerActivate();
                canToggle = false;
            }
        }
    }


    private void TriggerActivate()
    {
        //Debug.Log("LeverToggle.TriggerActivate: Did I Work?");


        // Change the Lever
        if (leverState)
        {
            //Debug.Log("thrown to the left");
            leverTransform.Rotate(0, 180, 0);
            leverRenderer.sharedMaterial = materials[0];
        }
        else
        {
            //Debug.Log("thrown to the right");
            leverTransform.Rotate(0, 180, 0);
            leverRenderer.sharedMaterial = materials[1];
        }

        // Toggle all of the objects
        // https://forgetcode.com/csharp/1188-looping-through-a-list-with-for-and-foreach
        foreach (GameObject targetObject in targetObjects)
        {
            //Debug.Log("LeverToggle.TriggerActivate: I did!");
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
