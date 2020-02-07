using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        Game.Instance.PauseMenu.UnPause();
    }
}
