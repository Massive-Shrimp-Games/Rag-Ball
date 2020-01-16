using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance { get; private set; }
    public GameObject controllerPrefab;

    private List<ControllerEventForwarder> controllers;

    public ControllerEventForwarder GetController(int index)
    {
        if (index < 0 || index >= controllers.Count)
        {
            return null;
        }
        return controllers[index];
    }

    private void Awake()
    {
        CreateSingleton();
        CreateControllers();
        GetChildren();
    }

    private void CreateSingleton()
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
    }

    private void CreateControllers()
    {
        int playerIndex = 0;
        foreach (Gamepad gamepad in Gamepad.all)
        {
            InputDevice inputDevice = gamepad.device;
            Debug.LogFormat("Device {0}", inputDevice);
            PlayerInput playerInput = PlayerInput.Instantiate(controllerPrefab,
                                                              playerIndex: playerIndex,
                                                              splitScreenIndex: -1,
                                                              controlScheme: "Gamepad",
                                                              pairWithDevice: inputDevice
                                                             );
            playerInput.transform.SetParent(this.gameObject.transform);
            playerInput.transform.name = string.Format("Controller #{0}", playerIndex);
            playerIndex++;
        }

        //foreach (InputDevice inputDevice in InputDevice.all)
        //{
        //    Debug.LogFormat("Input Device {0}", inputDevice);
        //}
    }

    private void GetChildren()
    {
        controllers = new List<ControllerEventForwarder>();

        foreach (Transform child in transform)
        {
            ControllerEventForwarder cef = child.GetComponent<ControllerEventForwarder>();
            controllers.Add(cef);
        }
    }
}
