using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgainButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
