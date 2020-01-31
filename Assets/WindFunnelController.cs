using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindFunnelController : MonoBehaviour
{
    public bool WindFunnelToggle = false;
    public float speed = 10f;
    public GameObject WindFunnelHolder;
    
    void Update()
    {
        if (WindFunnelToggle == false)
        {
            transform.Rotate(Vector3.up * 0);
            WindFunnelHolder.SetActive(false);
        }

        if (WindFunnelToggle == true)
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
            WindFunnelHolder.SetActive(true);
        }
    }
}
