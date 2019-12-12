﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public Canvas CourtLevel;
    public Canvas LedgeLevel;
    public RawImage[] GameModes;
    private int GameModeIndex;
    public RawImage[] Levels;
    private int LevelsIndex;
    public RawImage PipeMovementCross;
    public RawImage SlippyCross;
    public RawImage NoWallsCross;
    public CustomizationManager myCustomizationManager;

    void Start()
    {
        GameModeIndex = 0;
        LevelsIndex = 0;
        PipeMovementCross.enabled = true;
        SlippyCross.enabled = true;
        NoWallsCross.enabled = true;
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

        for (int i = 0; i < GameModes.Length; i++)
        {
            GameModes[i].enabled = false;
        }
        GameModes[GameModeIndex].enabled = true;

        for (int i = 0; i < Levels.Length; i++)
        {
            Levels[i].enabled = false;
        }
        Levels[LevelsIndex].enabled = true;

    }

    public void switchLevelLeft()
    {
        LevelsIndex -= 1;
        if (LevelsIndex < 0)
        {
            LevelsIndex = Levels.Length - 1;
        }
    }

    public void switchLevelRight()
    {
        LevelsIndex += 1;
        if (LevelsIndex > Levels.Length - 1)
        {
            LevelsIndex = 0;
        }
    }

    public void switchGameModeUp()
    {
        GameModeIndex += 1;
        if (GameModeIndex > GameModes.Length -1)
        {
            GameModeIndex = 0;
        }
    }

    public void switchGameModeDown()
    {
        GameModeIndex -= 1;
        if (GameModeIndex < 0)
        {
            GameModeIndex = GameModes.Length - 1;
        }
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
