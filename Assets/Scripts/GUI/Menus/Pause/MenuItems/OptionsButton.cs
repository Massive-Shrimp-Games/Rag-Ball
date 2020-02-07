using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        Debug.Log("Button Options");
    }
}
