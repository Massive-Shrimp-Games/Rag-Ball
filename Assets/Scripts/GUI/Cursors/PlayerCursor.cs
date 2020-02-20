using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerCursor : MonoBehaviour
{
    public MenuItem currentMenuItem;
    public int playerNumber;
    public bool active = true;

    private Controller controller;

    protected virtual void Start()
    {
        //BindController();
        //MapControls();
        //MoveToCurrentMenuItem();
    }

    protected virtual void OnDestroy()
    {
        //UnmapControls();
    }

    protected virtual void OnEnable()
    {
        BindController();
        MapControls();
        MoveToCurrentMenuItem();
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
