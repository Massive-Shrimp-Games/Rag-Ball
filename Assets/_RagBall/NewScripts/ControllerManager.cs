using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public static ControllerManager Instance { get; private set; }
    private Controller[] controllers;

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

        controllers = new Controller[4];
        controllers[0] = new Controller();
    }

    private void OnEnable()
    {
        foreach (Controller controller in controllers)
        {
            if (controller != null)
            {
                controller.Enable();
            }
        }
    }

    private void OnDisable()
    {
        foreach (Controller controller in controllers)
        {
            if (controller != null)
            {
                controller.Disable();
            }
        }
    }

    public Controller GetController(int index)
    {
        return controllers[index];
    }
}
