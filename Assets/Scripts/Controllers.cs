using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controllers : MonoBehaviour
{
    public GameObject controllerPrefab;
    private List<Controller> controllers;

    public Controller GetController(int index)
    {
        if (controllers == null || index < 0 || index >= controllers.Count)
        {
            return null;
        }
        return controllers[index];
    }

    private void Awake()
    {
        CreateControllers();
        GetChildren();
    }

    private void CreateControllers()
    {
        int playerIndex = 0;
        foreach (Gamepad gamepad in Gamepad.all)
        {
            InputDevice inputDevice = gamepad.device;
            Debug.LogFormat("Controllers - Device #{0} {1}", playerIndex, inputDevice);
            PlayerInput playerInput = PlayerInput.Instantiate(controllerPrefab,
                                                              playerIndex: playerIndex,
                                                              pairWithDevice: inputDevice
                                                             );
            playerInput.transform.SetParent(this.gameObject.transform);
            playerInput.transform.name = string.Format("Controller #{0}", playerIndex);
            playerIndex++;
        }
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

    public int Count(){
        return controllers.Count;
    }
}
