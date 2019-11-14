using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{

    public Canvas PauseMenu;
    public void Resume()
    {
        PauseMenu.enabled = false;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        
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
