using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://github.com/peter201943/Rag-Ball-Historic/blob/Multiplayer-Work/Assets/_RagBall/Scripts/PipePingPong.cs

public class PipePingPong : MonoBehaviour
{
    public float min;
    public float max;
    public float speed = 2f;
    [SerializeField] private bool PingPongAble = false;

    // Update is called once per frame
    void Update()
    {
        if (PingPongAble)
        { 
            transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, max - min) + min);
        }
    }
}
