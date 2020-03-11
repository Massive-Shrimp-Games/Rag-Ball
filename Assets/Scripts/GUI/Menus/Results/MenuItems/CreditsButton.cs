using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : Button
{
    public GameObject CreditsScreen;

    public override void Select(PlayerCursor cursor)
    {
        CreditsScreen.SetActive(true);
        cursor.hasControl = false;
    }
}
