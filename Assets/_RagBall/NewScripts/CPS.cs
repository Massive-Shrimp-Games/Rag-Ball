using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Collider Parent System
public class CPS : MonoBehaviour
{

    public delegate void Trigger(Collider other);

    public event Trigger _OnTriggerEnter;
    //public event Trigger _OnTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        _OnTriggerEnter(other);
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    _OnTriggerExit(other);
    //}
}
