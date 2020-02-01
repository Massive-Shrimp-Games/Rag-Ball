using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private Controller controller;

    private void Start()
    {
        if (Game.Instance == null) return;
        Game.Instance.Controllers.GetController(0)._OnStart += OnStart;
    }

    private void OnStart(InputValue inputValue)
    {
        SceneManager.LoadScene("GameModeSelect");
    }
}
