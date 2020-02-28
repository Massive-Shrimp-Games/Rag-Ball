using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// :) Peter was here
/// </summary>
public class CustomizationFactory : MonoBehaviour
{
    public bool FanEnabled;

    public GameObject Fan_Spinner;
    public GameObject Fan_Lever;
    private LeverToggle leverToggle;
    
    public Transform[] spawnPoints;

    /// <summary>
    /// This spawns a Lever and a Fan, binds the Fan to the Lever, and sets all states to ON
    /// </summary>
    private void Start()
    {
        if (FanEnabled == true)
        {
            // Spawn the Fan
            GameObject fan = Instantiate(Fan_Spinner);
            // Spawn the Lever
            GameObject fan_lever = Instantiate(Fan_Lever);

            // Move the fan into position
            fan.transform.position = spawnPoints[0].position;
            // Move the lever into position
            fan_lever.transform.position = spawnPoints[1].position;

            // Find the Lever Toggle
            leverToggle = fan_lever.transform.GetChild(1).GetComponent<LeverToggle>();

            // set the state of the lever to OFF
            leverToggle.leverState = false;

            // Add the Fan to the Lever's Children
            leverToggle.targetObjects.Add(fan.transform.GetChild(0).gameObject);
        }
    }
}
