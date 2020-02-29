using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Transform respawnPoint;
    
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Something hit me");
        if (collision.gameObject.tag == "CollisionLayer")
        {
            Debug.Log("Player entered a goal");
            Player player = collision.GetComponent<BaseObject>().player;
            
            if (player == null) return;
            player.transform.position = respawnPoint.transform.position;
        }
    }
}
