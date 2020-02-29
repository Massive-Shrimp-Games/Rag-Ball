using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsButton : Button
{
    public GameObject optionsScreen;

    public override void Select(PlayerCursor cursor)
    {
        optionsScreen.SetActive(true);
        cursor.currentMenuItem = optionsScreen.transform.GetChild(1).GetComponent<MenuItem>();
    }
}
