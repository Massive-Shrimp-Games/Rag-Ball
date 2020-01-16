using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance { get; private set; }
    public GameObject empty;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        int playerIndex = 0;
        foreach (Gamepad gamepad in Gamepad.all)
        {
            InputDevice inputDevice = gamepad.device;
            Debug.LogFormat("Device {0}", inputDevice);
            PlayerInput playerInput = PlayerInput.Instantiate(empty, playerIndex: playerIndex, splitScreenIndex: -1,
                controlScheme: "Gamepad", pairWithDevice: inputDevice);
            playerInput.transform.SetParent(this.gameObject.transform);
            playerInput.transform.name = string.Format("Controller #{0}", playerIndex);
            playerIndex++;
        }

        //foreach (InputDevice inputDevice in InputDevice.all)
        //{
        //    Debug.LogFormat("Input Device {0}", inputDevice);
        //}
    }

    private void Update()
    {

    }
}
