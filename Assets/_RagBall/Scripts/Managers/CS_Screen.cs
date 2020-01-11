using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CS_Screen : MonoBehaviour
{
    public Canvas LetsGo;

    void Start()
    {
    	LetsGo.enabled = false;
    }

    void Update()
    {
        if (LetsGo.enabled && (Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4")))
        {
            SceneManager.LoadScene(2);
        }

        if (LetsGo.enabled && (Input.GetButtonDown("B1") || Input.GetButtonDown("B2") || Input.GetButtonDown("B3") || Input.GetButtonDown("B4")))
        {
            LetsGo.enabled = false;
        }

        if (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4"))
        {
            LetsGo.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(2);
        }
    }
}
