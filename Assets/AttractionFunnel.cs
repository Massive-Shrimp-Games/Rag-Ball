using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttractionFunnel : MonoBehaviour
{
    public GameObject FunnelPoint;
    [SerializeField] private float magnitude;
    void OnTriggerStay(Collider col)
    {
        Rigidbody colRigidbody = col.GetComponent<Rigidbody>();
        Vector3 directionDraw = FunnelPoint.transform.position - colRigidbody.position;
        Vector3 drawForce = directionDraw.normalized * magnitude;

        if (colRigidbody != null)
        {
            colRigidbody.AddForce(drawForce);
        }
    }
}
