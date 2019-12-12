using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public static CustomizationManager singleton = null;

    public bool PipeMovement = false;
    public bool Slippy = false;
    public bool WallsActive = false;

    void Awake()
    {
        //Check if instance already exists
        if (singleton == null)
        {
            //if not, set instance to this
            singleton = this;
        }

        //If instance already exists and it's not this:
        else if (singleton != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }


}
