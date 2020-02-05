using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public bool paused { get; private set; }
    private Controller controller;

    public void Pause(Controller controller)
    {
        this.controller = controller;
        //controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        paused = true;
    }

    public void UnPause()
    {
        //controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        this.controller = null;
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        paused = false;
    }
}
