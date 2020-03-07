using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        LevelSelect.hasFan = !LevelSelect.hasFan;
    }
}
