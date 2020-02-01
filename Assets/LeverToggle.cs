using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Activates and Deactivates a List of GameObjects
/// https://docs.unity3d.com/ScriptReference/GameObject.SetActive.html
/// https://docs.unity3d.com/ScriptReference/GameObject-activeSelf.html
/// https://answers.unity.com/questions/13356/how-can-i-assign-materials-using-c-code.html?_ga=2.257422796.611847350.1580512480-1535617163.1580512480
/// https://youtu.be/dJB07ZSiW7k (Scripting: Change Material of an Object | Unity Tutorial)
/// </summary>
public class LeverToggle : MonoBehaviour
{

    // Activate the Lever
    [SerializeField] private float triggerSpeed = 5f;
    private float incomingSpeed;


    // Message the targets
    [SerializeField] private List<GameObject> targetObjects = new List<GameObject>();


    // Change the appearance of the Lever
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private bool leverState;                                       // Controls position of Lever
    [SerializeField] private MeshRenderer leverRenderer;
    [SerializeField] private Transform leverTransform;


    private void Start()
    {
        leverTransform = GameObject.Find("PinLever_Model_01").transform;
        leverRenderer = GameObject.Find("InnerCylinder").GetComponent<MeshRenderer>();
        leverRenderer.sharedMaterial = materials[1];
    }


    private void OnCollisionEnter(Collision collision)
    {
        incomingSpeed = collision.relativeVelocity.magnitude;
        
        if (incomingSpeed >= triggerSpeed)
        {
            TriggerActivate();
        }
    }


    private void TriggerActivate()
    {

        // Change the Lever
        if (leverState)
        {
            leverTransform.Rotate(0, 180, 0);
            leverRenderer.sharedMaterial = materials[1];
        }
        else
        {
            leverTransform.Rotate(0, 180, 0);
            leverRenderer.sharedMaterial = materials[0];
        }


        // Toggle all of the objects
        // https://forgetcode.com/csharp/1188-looping-through-a-list-with-for-and-foreach
        foreach (GameObject targetObject in targetObjects)
        {
            targetObject.SetActive(!targetObject.activeSelf);
        }


        /*
        if (GameObject.Find("WindFunnel").GetComponent<WindFunnelController>().WindFunnelToggle)
        {
            GameObject.Find("PinLever_Model_01").transform.Rotate(0, 180, 0);
            GameObject.Find("InnerCylinder").GetComponent<MeshRenderer>().material = disabledMat;
            GameObject.Find("WindFunnel").GetComponent<WindFunnelController>().WindFunnelToggle = false;
        }
        if (GameObject.Find("WindFunnel").GetComponent<WindFunnelController>().WindFunnelToggle == false)
        {
            GameObject.Find("PinLever_Model_01").transform.Rotate(0, 180, 0);
            GameObject.Find("InnerCylinder").GetComponent<MeshRenderer>().material = enabledMat;
            GameObject.Find("WindFunnel").GetComponent<WindFunnelController>().WindFunnelToggle = true;
        }
        */
    }
}
