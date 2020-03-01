using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Transform respawnPoint;
    private GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            Debug.Log("Respawn Me!!!");
            player = other.transform.parent.gameObject;
            Debug.Log(player);
            if (player == null)
            {
                return;
            }

            player.transform.position = respawnPoint.transform.position;
        }
        else
        {
            Debug.Log("Hello, Im being grabbed");
        }
        
    }
}
