

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


/// <summary>
/// A simple free camera to be added to a Unity game object.
/// 
/// Keys:
/// wasd / arrows   - movement
/// q/e             - up/down (local space)
/// r/f             - up/down (world space)
/// pageup/pagedown - up/down (world space)
/// hold shift      - enable fast movement mode
/// right mouse     - enable free look/move
/// mouse           - free look / rotation
/// p               - Enable/Disable FreeCam
///     
/// </summary>
public class FreeCam : MonoBehaviour
{

    /// <summary>
    /// Normal speed of camera movement.
    /// </summary>
    public float movementSpeed = 10f;


    /// <summary>
    /// Speed of camera movement when shift is held down,
    /// </summary>
    public float fastMovementSpeed = 100f;


    /// <summary>
    /// Sensitivity for free look.
    /// </summary>
    public float freeLookSensitivity = 3f;


    /// <summary>
    /// Amount to zoom the camera when using the mouse wheel.
    /// </summary>
    public float zoomSensitivity = 10f;


    /// <summary>
    /// Amount to zoom the camera when using the mouse wheel (fast mode).
    /// </summary>
    public float fastZoomSensitivity = 50f;


    /// <summary>
    /// Set to true when free looking (on right mouse button).
    /// </summary>
    private bool looking = false;


    /// <summary>
    /// Set to true when free moving (on right mouse button).
    /// </summary>
    private bool moving = false;


    /// <summary>
    /// Stops camera from receiving input commands
    /// </summary>
    public bool working = true;


    /// <summary>
    /// Do we want the camera to move fast or slow?
    /// </summary>
    private bool fastMode = false;


    /// <summary>
    /// Vars; Keys; Mouse
    /// </summary>
    void Update()
    {
        SetVars();

        KeyDecode();

        MoveMouse();

        CheckMouse();
    }


    /// <summary>
    /// Checks if we can start moving.
    /// </summary>
    private void SetVars()
    {
        fastMode = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        movementSpeed = fastMode ? this.fastMovementSpeed : this.movementSpeed;
    }


    /// <summary>
    /// Checks if we can start moving.
    /// </summary>
    private void KeyDecode()
    {
        WorkingMovingCommands();

        WorkingCommands();

        NotWorkingCommands();
    }


    /// <summary>
    /// Checks working commands
    /// </summary>
    private void WorkingMovingCommands()
    {
        if (working && moving)
        {
            /// <summary>
            /// Strafe Left
            /// </summary>
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = transform.position + (-transform.right * movementSpeed * Time.deltaTime);
            }


            /// <summary>
            /// Strafe Right
            /// </summary>
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = transform.position + (transform.right * movementSpeed * Time.deltaTime);
            }


            /// <summary>
            /// Move Forward
            /// </summary>
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position = transform.position + (transform.forward * movementSpeed * Time.deltaTime);
            }


            /// <summary>
            /// Move Backward
            /// </summary>
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position = transform.position + (-transform.forward * movementSpeed * Time.deltaTime);
            }


            /// <summary>
            /// Move Up
            /// </summary>
            if (Input.GetKey(KeyCode.Q))
            {
                transform.position = transform.position + (transform.up * movementSpeed * Time.deltaTime);
            }


            /// <summary>
            /// Move Down
            /// </summary>
            if (Input.GetKey(KeyCode.E))
            {
                transform.position = transform.position + (-transform.up * movementSpeed * Time.deltaTime);
            }
        }
    }


    /// <summary>
    /// Working but not moving
    /// </summary>
    private void WorkingCommands()
    {
        if (working)
        {
            /// <summary>
            /// Stop Working
            /// </summary>
            if (Input.GetKey(KeyCode.P))
            {
                StopWorking();
            }
        }
    }


    /// <summary>
    /// Checks if we can start moving.
    /// </summary>
    private void NotWorkingCommands()
    {
        if (!working)
        {
            /// <summary>
            /// Start Working
            /// </summary>
            if (Input.GetKey(KeyCode.P))
            {
                StartWorking();
            }
        }
    }


    /// <summary>
    /// Checks if we can start moving.
    /// </summary>
    private void CheckMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartLooking();
            StartMoving();
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopLooking();
            StopMoving();
        }
    }


    /// <summary>
    /// Set the camera direction
    /// </summary>
    private void MoveMouse()
    {
        if (looking && working)
        {
            float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * freeLookSensitivity;
            float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y") * freeLookSensitivity;
            transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
        }

        float axis = Input.GetAxis("Mouse ScrollWheel");

        if (axis != 0)
        {
            var zoomSensitivity = fastMode ? this.fastZoomSensitivity : this.zoomSensitivity;
            transform.position = transform.position + transform.forward * axis * zoomSensitivity;
        }
    }


    /// <summary>
    /// Disable all functionality of this object.
    /// </summary>
    void OnDisable()
    {
        StopLooking();
    }


    /// <summary>
    /// Enable free looking.
    /// </summary>
    public void StartLooking()
    {
        looking = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    /// <summary>
    /// Enable free moving.
    /// </summary>
    public void StartMoving()
    {
        moving = true;
    }


    /// <summary>
    /// Disable free looking.
    /// </summary>
    public void StopLooking()
    {
        looking = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    /// <summary>
    /// Disable free moving.
    /// </summary>
    public void StopMoving()
    {
        moving = false;
    }


    /// <summary>
    /// Disable inputs
    /// </summary>
    private void StopWorking()
    {
        working = false;
    }


    /// <summary>
    /// Disable free moving.
    /// </summary>
    public void StartWorking()
    {
        working = true;
    }
}