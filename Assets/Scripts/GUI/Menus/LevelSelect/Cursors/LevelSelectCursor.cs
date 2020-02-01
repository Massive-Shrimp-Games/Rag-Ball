using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelectCursor : PlayerCursor
{
    protected override void OnReturn(InputValue inputValue)
    {
        SceneManager.LoadScene("GameModeSelect");
    }

    protected override void OnStart(InputValue inputValue) { }
}
