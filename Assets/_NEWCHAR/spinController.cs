using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinController : MonoBehaviour
{

    // VARIABLES
    public float rotateSpeed = 200f;
    private bool spinLeft = false;
    private bool spinRight = false;


    void Update()
    {

        // Right Turn
        if (Input.GetKeyDown(KeyCode.A))
        {
            spinRight = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            spinRight = false;
        }


        // Left Turn
        if (Input.GetKeyDown(KeyCode.D))
        {
            spinLeft = true;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            spinLeft = false;
        }


        SpinLeft();
        SpinRight();
    }


    private void SpinLeft()
    {
        if (spinLeft)
        {
            //transform.parent.GetChild(0).Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
    }


    private void SpinRight()
    {
        if (spinRight)
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }
    }
}
