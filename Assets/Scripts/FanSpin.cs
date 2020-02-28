using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanSpin : MonoBehaviour
{
    public float speed = 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("FanSpin.Update: Speed is: " + speed);
       gameObject.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
