using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public Canvas CourtLevel;
    public Canvas LedgeLevel;
    public CustomizationManager myCustomizationManager;

    void Start()
    {
        CourtLevel.enabled = true;
        LedgeLevel.enabled = false;
    }

    void Update()
    {
        if ((Input.GetButtonDown("B1") || Input.GetButtonDown("B2") || Input.GetButtonDown("B3") || Input.GetButtonDown("B4")))
        {
            SceneManager.LoadScene(1);
        }

        if (LedgeLevel.enabled && (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4")))
        {
            SceneManager.LoadScene(3);
        }

        if (CourtLevel.enabled && (Input.GetButtonDown("Start1") || Input.GetButtonDown("Start2") || Input.GetButtonDown("Start3") || Input.GetButtonDown("Start4")))
        {
            SceneManager.LoadScene(4);
        }

        if (CourtLevel.enabled && (Input.GetButtonDown("Right Bumper1") || Input.GetButtonDown("Right Bumper2") || Input.GetButtonDown("Right Bumper3") || Input.GetButtonDown("Right Bumper4")))
        {
            CourtLevel.enabled = false;
            LedgeLevel.enabled = true;
        }

        if (LedgeLevel.enabled && (Input.GetButtonDown("Left Bumper1") || Input.GetButtonDown("Left Bumper2") || Input.GetButtonDown("Left Bumper3") || Input.GetButtonDown("Left Bumper4")))
        {
            CourtLevel.enabled = true;
            LedgeLevel.enabled = false;
        }
    }

    public void switchLevel()
    {
        if (CourtLevel.enabled && (Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4")))
        {
            CourtLevel.enabled = false;
            LedgeLevel.enabled = true;
        }

        if (LedgeLevel.enabled && (Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4")))
        {
            CourtLevel.enabled = true;
            LedgeLevel.enabled = false;
        }
    }

    public void switchGameMode()
    {

    }

    public void Time()
    {

    }

    public void Score()
    {

    }

    public void addTime()
    {

    }

    public void subTime()
    {

    }

    public void addScore()
    {

    }

    public void subScore()
    {

    }

    public void PipeMovementActive()
    {

    }

    public void SlipperyFloorActive()
    {

    }

    public void NoWallsActive()
    {

    }
}
