using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controllers : MonoBehaviour
{
    public static Controllers Instance { get; private set; }
    public GameObject controllerPrefab;

    private List<Controller> controllers;

    public Controller GetController(int index)
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
        controllers = new List<Controller>();

        foreach (Transform child in transform)
        {
            Controller cef = child.GetComponent<Controller>();
            controllers.Add(cef);
        }
    }
}
