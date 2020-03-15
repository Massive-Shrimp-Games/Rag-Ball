using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDoors : MonoBehaviour
{
    private GameObject player;
    public List<Transform> DoorPoints = new List<Transform>();

    public void OnTriggerEnter(Collider other)
    {
        BaseObject p = other.GetComponent<BaseObject>();
        if (p)
        {
            player = p.player.getHips();

            player.transform.position = DoorPoints[Random.Range(0,3)].transform.position;
            player.transform.rotation = DoorPoints[0].transform.rotation;
        }
        else
        {
            Debug.Log("Hello, Im being grabbed");
        }

    }
}
