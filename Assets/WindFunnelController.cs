using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFunnelController : MonoBehaviour
{

    public float runSpeed = 700f;           // How fast we rotate when activated
    public float stopSpeed = 0f;            // How fast we rotate when deactivated

    public GameObject fanModel;             // What we rotate
    private FanSpin fanSpin;                // What we tell to rotate


    private void Awake()
    {
        fanSpin = fanModel.GetComponent<FanSpin>();
    }


    private void OnEnable()
    {
        Debug.Log("WindFunnelController: RUNNING");
        fanSpin.speed = runSpeed;
    }


    private void OnDisable()
    {
        Debug.Log("WindFunnelController: stopping");
        fanSpin.speed = stopSpeed;
    }


}
