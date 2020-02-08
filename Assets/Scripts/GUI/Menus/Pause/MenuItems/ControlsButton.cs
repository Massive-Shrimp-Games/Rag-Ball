using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        Debug.Log("Button Controls");
    }
}
