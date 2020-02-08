using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private Controller controller;

    private void Start()
    {
        if (Game.Instance == null) return;
        MapControls();
    }

    private void OnDestroy()
    {
        UnMapControls();
    }

    private void MapControls()
    {
        controller = Game.Instance.Controllers.GetController(0);
        if (controller != null)
        {
            controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
            controller._OnStart += OnStart;
            controller._OnNavigate += OnNavigate;
            controller._OnConfirm += OnConfirm;
            controller._OnReturn += OnReturn;
        }
    }

    private void UnMapControls()
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
        SceneManager.LoadScene("GameModeSelect");
    }

    private void OnNavigate(InputValue inputValue) { }
    private void OnConfirm(InputValue inputValue) { }
    private void OnReturn(InputValue inputValue) { }
}
