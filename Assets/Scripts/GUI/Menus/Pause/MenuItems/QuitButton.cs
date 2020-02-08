using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        if (Game.Instance == null) return;
        Game.Instance.PauseMenu.UnPause();
        SceneManager.LoadScene("Title");
    }
}