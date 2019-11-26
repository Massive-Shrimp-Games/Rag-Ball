using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Canvas PauseCanvas;
    public Canvas SettingsCanvas;

    public void OnMouseUp()
    {
        PauseCanvas.GetComponent<Canvas>().enabled = false;
        SettingsCanvas.GetComponent<Canvas>().enabled = true;
    }
}
