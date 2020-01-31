using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipesMoveButton : Button
{
    public override void Select(Cursor cursor)
    {
        LevelSelect.pipesMove = !LevelSelect.pipesMove;
    }
}
