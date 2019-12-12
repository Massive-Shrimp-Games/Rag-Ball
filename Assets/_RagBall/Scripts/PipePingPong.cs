using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipePingPong : MonoBehaviour
{
    public float min;
    public float max;
    private bool PingPongAble;
    

    public void Awake()
    {
        PingPongAble = CustomizationManager.CM.PipeMovement;
    }

    // Update is called once per frame
    void Update()
    {
        if (PingPongAble)
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * 2, max - min) + min);
    }
}
