using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrab : MonoBehaviour
{
    [SerializeField] private List<GameObject> grabbables;
    [SerializeField] private GameObject hips;

    private void Start()
    {
        grabbables = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider collided) {
        if (grabbables.Contains(collided.gameObject) ) { return; }

        if (collided.gameObject.tag == "Grabbable") {
            grabbables.Add(collided.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        grabbables.Remove(other.gameObject);
    }

    public GameObject FindClosest()
    {
        Debug.Log("FindClosest called");
        if (grabbables.Count == 0) { return null; }

        GameObject nearest = null;
        foreach (GameObject grab in grabbables)
        {
            Player player = grab.GetComponent<BaseObject>().player;
            if (nearest == null && grab.tag != "Grabbed")
            {
                //if is a player and they are staggered
                if (player != null && player.staggered)
                    nearest = grab;
                //otherwise if they are not a player (already checked if grabbable) must be a grabbable object of type not player
                else if (player == null)
                    nearest = grab;
            }
           if (nearest != null)
            {
                float grabDistance = Vector3.Distance(hips.transform.position, grab.transform.position);
                float nearestDistance = Vector3.Distance(hips.transform.position, nearest.transform.position);
                if (grabDistance < nearestDistance)
                {
                    nearest = grab;
                }
            }

            
        }

        return nearest;
    }
}
