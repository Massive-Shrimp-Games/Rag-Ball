using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairScene : MonoBehaviour
{

		public float myForce = 1000f;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, -myForce);
    }
}
