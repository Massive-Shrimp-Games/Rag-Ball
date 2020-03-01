using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        SceneManager.LoadScene("MainMenu");
    }
}
