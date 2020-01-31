using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
    public int playerNumber;
    public MenuItem currentMenuItem;

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
        currentMenuItem = currentMenuItem.Navigate(inputValue);
        gameObject.transform.position = currentMenuItem.Position;
        Debug.LogFormat("Cursor position is {0}", gameObject.transform.position);
    }

    private void OnConfirm(InputValue inputValue)
    {
        currentMenuItem.Select(this);
    }

    private void OnReturn(InputValue inputValue)
    {

    }
}
