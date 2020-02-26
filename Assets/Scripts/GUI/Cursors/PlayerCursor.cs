using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerCursor : MonoBehaviour
{
    public MenuItem currentMenuItem;
    public int playerNumber;
    public bool hasControl = true;

    private Controller controller;

    protected virtual void Start()
    {
        MoveToCurrentMenuItem();
    }

    protected virtual void OnDestroy()
    {
    }

    protected virtual void OnEnable()
    {
        BindController();
        MapControls();
    }

    protected virtual void OnDisable()
    {
        UnmapControls();
    }

    private void BindController()
    {
        if (Game.Instance == null) return;
        controller = Game.Instance.Controllers.GetController(playerNumber);
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

    protected virtual void OnNavigate(InputValue inputValue)
    {
        if (hasControl)
        {
            currentMenuItem = currentMenuItem.Navigate(inputValue);
            MoveToCurrentMenuItem();
        }
    }

    protected virtual void OnConfirm(InputValue inputValue)
    {
        currentMenuItem.Select(this);
    }

    protected abstract void OnStart(InputValue inputValue);
    protected abstract void OnReturn(InputValue inputValue);

    private void MoveToCurrentMenuItem()
    {
        Debug.Log("MoveToCurrentMenuItem");
        gameObject.transform.position = currentMenuItem.Position;
    }
}
