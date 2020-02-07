using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public abstract class PlayerCursor : MonoBehaviour
{

    // private static Mutex mutex = new Mutex();
    // public static GameObject Create(int playerNumber)
    // {
    //     // mutex.WaitOne();
    //     PlayerCursor.parameters = ScriptableObject.CreateInstance<PlayerCursorParameters>();
    //     // PlayerCursor.parameters.playerNumber = playerNumber;
    //     // mutex.ReleaseMutex();
    //     return Instantiate(parameters.prefab);
    // }
    // private static PlayerCursorParameters parameters;

    public MenuItem currentMenuItem;
    public bool active = true;

    public int playerNumber;
    private Controller controller;

    private void Start()
    {
        BindController(playerNumber);
    }

    private void OnDestroy()
    {
        UnmapControls();
    }

    public void BindController(int playerNumber)
    {
        if (Game.Instance == null) return;
        controller = Game.Instance.Controllers.GetController(playerNumber);
        UnmapControls();
        controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        gameObject.transform.position = currentMenuItem.Position;
        MapControls();
    }

    private void MapControls()
    {
        if (controller != null)
        {
            controller._OnStart += OnStart;
            controller._OnNavigate += OnNavigate;
            controller._OnConfirm += OnConfirm;
            controller._OnReturn += OnReturn;
        }
    }

    private void UnmapControls()
    {
        if (controller != null)
        {
            controller._OnStart -= OnStart;
            controller._OnNavigate -= OnNavigate;
            controller._OnConfirm -= OnConfirm;
            controller._OnReturn -= OnReturn;
            controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
    }

    private void OnNavigate(InputValue inputValue)
    {
        if (active)
        {
            currentMenuItem = currentMenuItem.Navigate(inputValue);
            gameObject.transform.position = currentMenuItem.Position;
        }
    }

    private void OnConfirm(InputValue inputValue)
    {
        currentMenuItem.Select(this);
    }

    protected abstract void OnStart(InputValue inputValue);
    protected abstract void OnReturn(InputValue inputValue);
}
