using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen: MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Start") || Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4"))
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }
}
