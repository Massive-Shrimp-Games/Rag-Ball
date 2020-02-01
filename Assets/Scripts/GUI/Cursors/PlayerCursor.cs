using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
    public int playerNumber;
    public MenuItem currentMenuItem;
    public bool active = true;

    private Controller controller;

    private void Start()
    {
        if (Game.Instance == null)
        {
            return;
        }
        BindController(playerNumber);
    }

    private void OnDestroy()
    {
        UnmapControls();
    }

    public void BindController(int playerNumber)
    {
        UnmapControls();
        this.playerNumber = playerNumber;
        controller = Game.Instance.Controllers.GetController(playerNumber);
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
        }
    }

    private void OnStart(InputValue inputValue)
    {

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

    private void OnReturn(InputValue inputValue)
    {

    }
}
