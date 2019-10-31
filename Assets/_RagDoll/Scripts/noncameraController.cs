using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noncameraController : MonoBehaviour
{

    //https://answers.unity.com/questions/10443/how-to-rotate-an-objects-x-y-z-based-on-mouse-move.html
    public Transform rotatePlayer;

    public Transform pivot;
    public Camera cam;

    public float horizontalSpeed = .02f;
    public float verticalSpeed = 1f;
    public float rotSpeed = 1;
    public float rot = 180;


    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Mouse X") * horizontalSpeed;
        float v = Input.GetAxis("Mouse Y") * verticalSpeed;

        rotatePlayer.RotateAround(pivot.position, Vector3.up, h * horizontalSpeed / Time.deltaTime);

        cam.transform.localRotation *= Quaternion.Euler(-v, 0f, 0f);
        cam.transform.localRotation = ClampRoatationAroundXAxis(cam.transform.localRotation);

        if (Input.GetKeyDown(KeyCode.A))
            RotateLeft();
        else if (Input.GetKeyUp(KeyCode.A))
            RotateLeft();
    }


    void RotateLeft()
    {
        transform.localEulerAngles = new Vector3(-Mathf.PingPong(Time.time * rotSpeed, rot), 0, 0);
    }


    Quaternion ClampRoatationAroundXAxis(Quaternion q){
         q.x /= q.w;
         q.y /= q.w;
         q.z /= q.w;
         q.w = 1.0f;
         float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);
         angleX = Mathf.Clamp(angleX, -70f, 60f);
         q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);
         return q;
    }
}
