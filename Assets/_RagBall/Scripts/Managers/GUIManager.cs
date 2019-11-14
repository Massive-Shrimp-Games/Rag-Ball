using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Canvas PauseMenu;
    public RawImage ControlsImage;
    public void Resume()
    {
        PauseMenu.enabled = false;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        ControlsImage.enabled = true;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
    }

    public void Options()
    {
        
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
