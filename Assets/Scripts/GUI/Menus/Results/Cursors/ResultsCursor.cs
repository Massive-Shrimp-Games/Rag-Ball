using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResultsCursor : PlayerCursor
{
    protected override void OnStart(InputValue inputValue)
    {

    }

    protected override void OnConfirm(InputValue inputValue)
    {
        if (currentMenuItem.GetComponent<CreditsButton>() != null)
        {
            if (currentMenuItem.GetComponent<CreditsButton>().CreditsScreen.activeInHierarchy)
            {
                currentMenuItem.GetComponent<CreditsButton>().CreditsScreen.SetActive(false);
                hasControl = true;
            }
            else
            {
                currentMenuItem.Select(this);
            }
        }
        else
        {
            currentMenuItem.Select(this);
        }
    }

    protected override void OnReturn(InputValue inputValue)
    {
        if (currentMenuItem.GetComponent<CreditsButton>() != null)
        {
            if (currentMenuItem.GetComponent<CreditsButton>().CreditsScreen.activeInHierarchy)
            {
                currentMenuItem.GetComponent<CreditsButton>().CreditsScreen.SetActive(false);
                hasControl = true;
            }
        }
    }
}
