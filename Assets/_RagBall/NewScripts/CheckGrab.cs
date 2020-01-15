using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGrab : MonoBehaviour
{
    private void OnTriggerEnter(Collider collided) {
        if (collided.gameObject.tag == "Grabbable") {
            print(collided.gameObject.transform.name);
        }
    }
}
