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
        OptionsMenu.OptionsChangeEvent?.Invoke();
        if (controls && controls.active)
        {
            controls?.SetActive(false);
            MapNavigationControls();
        }
        else if (options && options.active)
        {
            options?.SetActive(false);
            currentMenuItem = GameObject.Find("Options").GetComponent<OptionsButton>();
            MoveToCurrentMenuItem();
        }
        else
        {
            options?.SetActive(false);
            controls?.SetActive(false);
            Game.Instance.PauseMenu.UnPause();
        }
    }

    protected override void OnStart(InputValue inputValue)
    {
        if (Game.Instance == null) return;
        GameObject controls = GameObject.Find("ControlsScreen");
        GameObject options = GameObject.Find("OptionsScreen");
        options?.SetActive(false);
        controls?.SetActive(false);
        Game.Instance.PauseMenu.UnPause();
        OptionsMenu.OptionsChangeEvent?.Invoke();
    }
}
