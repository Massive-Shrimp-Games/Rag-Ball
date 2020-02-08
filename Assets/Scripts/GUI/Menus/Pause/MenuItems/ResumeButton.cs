using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        if (Game.Instance == null) return;
        Game.Instance.PauseMenu.UnPause();
    }
}
