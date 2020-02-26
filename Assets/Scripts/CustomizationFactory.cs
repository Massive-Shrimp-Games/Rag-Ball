using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationFactory : MonoBehaviour
{
    public bool FanEnabled;

    public GameObject Fan_Spinner;
    public GameObject Fan_Lever;
    
    public Transform[] spawnPoints;

    private void Start()
    {
        if (FanEnabled == true)
        {
            GameObject fan = Instantiate(Fan_Spinner);
            GameObject fan_lever = Instantiate(Fan_Lever);
            fan.transform.position = spawnPoints[0].position;
            fan_lever.transform.position = spawnPoints[1].position;
        }
    }
}
