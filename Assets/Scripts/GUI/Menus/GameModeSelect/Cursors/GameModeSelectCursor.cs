using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameModeSelectCursor : PlayerCursor
{
    protected override void OnReturn(InputValue inputValue)
    {
        SceneManager.LoadScene("Title");
    }

    protected override void OnStart(InputValue inputValue) { }
}
