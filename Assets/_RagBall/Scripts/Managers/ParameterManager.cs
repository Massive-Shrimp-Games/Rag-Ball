using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public GameObject RedPipeParent;
    public GameObject BluePipeParent;
    public float PipeScale = 0.05f;

    public void PipeScaleChanged(float s)
    {
        Debug.Log("SCALING: " + s);
        PipeScale = s;
        RedPipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
        BluePipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
    }


    
    
}
