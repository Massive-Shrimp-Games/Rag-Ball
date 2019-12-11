using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour
{

    // myPlayer = player tracking integer
    // theirHips = any triggering object's possible hips
    // iCanGrab = stops player from grabbing if they are currently being grabbed
    // grabMode = provides context to the grab button in godscript

    public int myPlayer = -666;
    public GameObject tharHips;
    public GameObject oldHips;
    public bool iCanGrab = true;
    public string grabMode = "free";

    /*
        public void OnTriggerEnter(Collider theTriggerer)
        {
            if (theTriggerer.gameObject.layer != 13)
            {
                AssignTrigger(theTriggerer);
            }
            else
            {
                Debug.Log("Da floor is not alloweD!");
            }
        }
    */

    public void OnTriggerEnter(Collider theTriggerer)
    {

        //Debug.Log("I AM OFFICIALLY TRIGGERED!!!!!!!!!");

        Grabbable testGrabbable = theTriggerer.GetComponent<Grabbable>();
        if (testGrabbable != null)
        {
            AssignTrigger(theTriggerer);
        }
        /*else
        {
            Debug.Log("WTF is this?!?!?: " + theTriggerer);
        }*/
    }

    public void AssignTrigger(Collider theTriggerer)
    {
        Debug.Log("I can FEEEL somethin!");

        Grabbable theirGrabbable = theTriggerer.GetComponent<Grabbable>();

        if ((theirGrabbable != null) && grabMode.Equals("free"))
        {
            Debug.Log("An' its got sum HIPS BOI!");
            tharHips = theTriggerer.gameObject;
            oldHips = tharHips;
        }
    }

    public void OnTriggerExit(Collider theTriggerer)
    {
        tharHips = null;
    }

}



// Had to ignore the floor, but of course
// https://answers.unity.com/questions/686915/how-do-i-get-some-objects-to-ignore-collision-with.html

