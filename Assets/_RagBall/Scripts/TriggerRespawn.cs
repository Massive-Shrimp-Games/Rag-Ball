using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRespawn : MonoBehaviour
{
    public Transform RespawnPosition;

    void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.position = RespawnPosition.position;
    }
}
