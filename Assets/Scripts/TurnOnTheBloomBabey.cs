using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TurnOnTheBloomBabey : MonoBehaviour
{
    public GameObject getOTF;
    PostProcessVolume itsTheVolume;
    public float weightNum = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void turnOnOrOffThatBloom()
    {
        itsTheVolume = getOTF.GetComponent<PostProcessVolume>();
        if (itsTheVolume.weight == weightNum)
        {
            itsTheVolume.weight = 0;
        }
        else
        {
            itsTheVolume.weight = weightNum;
        }
        //should turn it on or off 

    }
}
