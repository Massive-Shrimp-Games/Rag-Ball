using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        SceneManager.LoadScene("Title");
    }
}