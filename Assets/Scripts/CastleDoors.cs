using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoors : MonoBehaviour
{
    private GameObject player;
    public List<Transform> DoorPoints = new List<Transform>();

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

            player.transform.position = DoorPoints[Random.Range(0,3)].transform.position;
            player.transform.rotation = DoorPoints[0].transform.rotation;
        }
        else
        {
            Debug.Log("Hello, Im being grabbed");
        }

    }
}
