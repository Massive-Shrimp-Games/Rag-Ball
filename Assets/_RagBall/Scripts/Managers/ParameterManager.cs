using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UI.Selectable;

public class ParameterManager : MonoBehaviour
{
    public GameObject RedPipeParent;
    public GameObject BluePipeParent;
    public float PipeScale = 0.05f;
    public Slider pipeRescaleSlider;



    public void PipeScaleChanged(float s)
    {
        Debug.Log("SCALING: " + s);
        PipeScale = s;
        RedPipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
        BluePipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
    }

    public void Update()
    {
        PipeScale = pipeRescaleSlider.value;
        RedPipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
        BluePipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
    }


    
    
}
