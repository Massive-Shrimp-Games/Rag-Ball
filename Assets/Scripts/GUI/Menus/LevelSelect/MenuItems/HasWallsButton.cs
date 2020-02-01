using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasWallsButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        LevelSelect.hasWalls = !LevelSelect.hasWalls;
    }
}
