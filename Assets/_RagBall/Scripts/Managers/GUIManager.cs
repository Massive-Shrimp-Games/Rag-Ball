using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Canvas PauseMenu;
    public RawImage ControlsImage;
    public PlayerManager playerManager;
    public Canvas ParameterCanvas;

    public void Resume()
    {
        PauseMenu.enabled = false;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        playerManager.GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void Controls()
    {
        ControlsImage.enabled = true;
       
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
    }

    public void Options()
    {
        ParameterCanvas.enabled = true;
        //PauseMenu.enabled = false;
        //PauseMenu.gameObject.SetActive(false);
        ParameterCanvas.GetComponent<CanvasGroup>().interactable = true;
        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
        Slider test = ParameterCanvas.transform.Find("GoalSize/GoalSizeSlider").GetComponent<Slider>();
        test.Select();

    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
