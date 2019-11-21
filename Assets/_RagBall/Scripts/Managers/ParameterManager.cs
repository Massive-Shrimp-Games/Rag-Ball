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
    public Slider daddySlider;



    public void PipeScaleChanged(float s)
    {
        Debug.Log("SCALING: " + s);
        PipeScale = s;
        RedPipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
        BluePipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
    }

    public void Update()
    {
        PipeScale = daddySlider.value;
        RedPipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
        BluePipeParent.transform.localScale = new Vector3(PipeScale, PipeScale, PipeScale);
    }


    
    
}
