using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float Strength;
    public Vector3 WindDirection;
    private void Update()
    {
        transform.Rotate(Vector3.up * 20.0f * Time.deltaTime);
    }
    void OnTriggerStay(Collider col)
    {
        Rigidbody colRigidbody = col.GetComponent<Rigidbody>();
        if (colRigidbody != null)
        {
            colRigidbody.AddForce(WindDirection * Strength);
        }
    }
}
