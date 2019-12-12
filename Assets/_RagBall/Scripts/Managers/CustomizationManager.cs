using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationManager : MonoBehaviour
{
    public static CustomizationManager CM;

    public bool PipeMovement = true;
    public bool Slippy = true;
    public bool WallsActive = true;
    public bool GoalsActive = false;
    public bool TimerActive = false;
    public int GoalsMax = 0;

    void Awake()
    {
        //Check if instance already exists
        if (CM == null)
        {
            DontDestroyOnLoad(gameObject);
            CM = this;
        }

        //If instance already exists and it's not this:
        else if (CM != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
            
        }
    }



    //https://answers.unity.com/questions/1072572/accessing-variables-on-a-script-on-a-dontdestroyon.html

}
