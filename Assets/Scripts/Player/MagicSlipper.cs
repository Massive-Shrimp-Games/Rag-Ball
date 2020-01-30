using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Documentation
/* NAME:        Magic Slipper
 * FOR:         Player
 * TALKS TO:    PlayerManager
 * UTILITY:     Tells the hips whether the player can jump or not (is there a nearby surface?)
 * AUTHOR:      Peter Mangelsdorf
 * DATE:        12 December 2019
 * ME:          complete
 * THEM:        incomplete
 */



public class MagicSlipper : MonoBehaviour
{

    public bool touching = false;       // Is this foot touching something?


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 15)
        { 
        touching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer != 15)
        { 
        touching = false;
        }
    }

}
