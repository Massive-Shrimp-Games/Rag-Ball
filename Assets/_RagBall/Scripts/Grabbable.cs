using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

    public int myPlayer = -666;
    public GameObject tharHips;
    public bool iCanGrab = true;

    public void OnTriggerEnter(Collider theTriggerer)
    {
        Debug.Log("I can FEEEL somethin!");

        Grabbable theirGrabbable = theTriggerer.GetComponent<Grabbable>();
        if (theirGrabbable != null)
        {
            Debug.Log("An' its got sum HIPS BOI!");

            tharHips = theTriggerer.gameObject;
            theirGrabbable.iCanGrab = false;
        }
    }

    public void OnTriggerExit(Collider theTriggerer)
    {
        Grabbable theirGrabbable = theTriggerer.GetComponent<Grabbable>();
        if (theirGrabbable != null)
        {
            theirGrabbable.iCanGrab = true;
        }
        tharHips = null;

    }

}
