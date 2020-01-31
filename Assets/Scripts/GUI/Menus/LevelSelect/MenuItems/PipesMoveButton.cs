using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMoveButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        LevelSelect.pipesMove = !LevelSelect.pipesMove;
    }
}
