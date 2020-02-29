using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Transform respawnPoint;
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Grabbable")
        {
            Player player = collision.GetComponent<BaseObject>().player;
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
