using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectCursor : PlayerCursor
{
    protected override void OnReturn(InputValue inputValue)
    {
        if (active)
        {
            SceneManager.LoadScene("LevelSelect");
        } else
        {
            active = true;
        }
    }

    protected override void OnStart(InputValue inputValue)
    {
        if (transform.parent.GetComponent<CursorCreator>().ready)
        {
            SceneManager.LoadScene("Main_Game2");
        }
    }
}
