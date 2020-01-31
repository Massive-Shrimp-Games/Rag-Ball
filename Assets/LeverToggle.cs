using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverToggle : MonoBehaviour
{
    [SerializeField]    private float triggerSpeed = 5f;
    private float incomingSpeed;
    public Material enabledMat;
    public Material disabledMat;


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
    }
}
