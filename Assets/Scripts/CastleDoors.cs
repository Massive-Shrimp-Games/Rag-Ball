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
            int rnd = Random.Range(0,3);
            p.player.movePlayer(DoorPoints[rnd].transform);
        }
        else
        {
            Debug.Log("Hello, Im being grabbed");
        }

    }
}
