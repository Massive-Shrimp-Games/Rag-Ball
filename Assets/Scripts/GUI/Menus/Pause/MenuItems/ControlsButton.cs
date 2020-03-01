using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsButton : Button
{
    public GameObject controlsImage;
    public override void Select(PlayerCursor cursor)
    {
        controlsImage.SetActive(true);
        controlsImage.transform.SetAsLastSibling();
        cursor.UnmapNavigationControls();
    }
}
