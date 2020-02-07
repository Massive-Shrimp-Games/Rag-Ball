using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading;

public abstract class PlayerCursor : MonoBehaviour
{
    public MenuItem currentMenuItem;
    public bool active = true;

    public int playerNumber;
    private Controller controller;

    private void Start()
    {
        BindController(playerNumber);
        MapControls();
        MoveToCurrentMenuItem();
    }

    private void OnDestroy()
    {
        UnmapControls();
    }

    public void BindController(int playerNumber)
    {
        if (Game.Instance == null) return;
        controller = Game.Instance.Controllers.GetController(playerNumber);
    }

    private void MapControls()
    {
        if (controller != null)
        {
            controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
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
            MoveToCurrentMenuItem();
        }
    }

    private void OnConfirm(InputValue inputValue)
    {
        currentMenuItem.Select(this);
    }

    protected abstract void OnStart(InputValue inputValue);
    protected abstract void OnReturn(InputValue inputValue);

    private void MoveToCurrentMenuItem()
    {
        gameObject.transform.position = currentMenuItem.Position;
    }
}
