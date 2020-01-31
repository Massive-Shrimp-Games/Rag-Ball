using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyFloorButton : Button
{
    public override void Select(Cursor cursor)
    {
        LevelSelect.slipperyFloor = !LevelSelect.slipperyFloor;
    }
}
