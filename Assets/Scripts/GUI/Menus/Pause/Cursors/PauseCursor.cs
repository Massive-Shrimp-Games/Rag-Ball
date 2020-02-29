using UnityEngine;
using UnityEngine.InputSystem;

public class PauseCursor : PlayerCursor
{
    protected override void Start()
    {
        ActionMapEvent.InMenu?.Invoke();
        base.Start();
    }

    protected override void OnDestroy()
    {
        ActionMapEvent.InGameplay?.Invoke();
        base.OnDestroy();
    }

    protected override void OnReturn(InputValue inputValue)
    {
        if (Game.Instance == null) return;
        GameObject controls = GameObject.Find("ControlsScreen");
        GameObject options = GameObject.Find("OptionsScreen");
        if (controls && controls.active)
        {
            controls.SetActive(false);
            MapNavigationControls();
        }
        else if (options && options.active)
        {
            options.SetActive(false);
            currentMenuItem = GameObject.Find("Options").GetComponent<OptionsButton>();
            MoveToCurrentMenuItem();
        }
        else
        {
            Game.Instance.PauseMenu.UnPause();
        }
    }

    protected override void OnStart(InputValue inputValue)
    {
        if (Game.Instance == null) return;
        Game.Instance.PauseMenu.UnPause();
    }
}
