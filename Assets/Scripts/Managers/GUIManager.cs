using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour
{
    public void Resume()
    {
        SceneManager.LoadScene(1);
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
    }
}
