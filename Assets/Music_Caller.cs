using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music_Caller : MonoBehaviour
{
    private int level;
    //the int level parameter matches the "int" within build settings
    //currently, int 5 == MainGame2.unity
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name + " : " + scene.buildIndex);


        switch (level)
        {
            case 1:
                Debug.Log("1");
                break;
            case 2:
                Debug.Log("2");
                break;
            case 3:
                Debug.Log("3");
                break;
            case 4:
                Debug.Log("4");
                break;
            case 5:
                //Game.Instance.SFX.StopAudio("goal");
                Game.Instance.SFX.PlayAudio("goal");
                break;

        }

    }
    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

}