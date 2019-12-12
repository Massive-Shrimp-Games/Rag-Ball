using System.Collections;
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
    

    void Start()
    {
        GameModeIndex = 0;
        LevelsIndex = 0;
        PipeMovementCross.enabled = false;
        SlippyCross.enabled = false;
        NoWallsCross.enabled = false;

        CustomizationManager.CM.PipeMovement = true;
        CustomizationManager.CM.WallsActive = true;
        CustomizationManager.CM.Slippy = true;
    }

    void Update()
    {
        if ((Input.GetButtonDown("B1") || Input.GetButtonDown("B2") || Input.GetButtonDown("B3") || Input.GetButtonDown("B4")))
        {
            SceneManager.LoadScene(1);
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
        if (PipeMovementCross.enabled == false)
        {
            PipeMovementCross.enabled = true;
            CustomizationManager.CM.PipeMovement = false;
        }

        else if (PipeMovementCross.enabled == true)
        {
            PipeMovementCross.enabled = false;
            CustomizationManager.CM.PipeMovement = true;
        }
    }

    public void SlipperyFloorActive()
    {
        if (SlippyCross.enabled == false)
        {
            SlippyCross.enabled = true;
            CustomizationManager.CM.Slippy = false;
        }

        else if (SlippyCross.enabled == true)
        {
            SlippyCross.enabled = false;
            CustomizationManager.CM.Slippy = true;
        }
    }

    public void NoWallsActive()
    {
        if (NoWallsCross.enabled == false)
        {
            NoWallsCross.enabled = true;
            CustomizationManager.CM.WallsActive = false;
        }

        else if (NoWallsCross.enabled == true)
        {
            NoWallsCross.enabled = false;
            CustomizationManager.CM.WallsActive = true;
        }
    }

    public void PlayButton()
    {
        if (LevelsIndex == 0)
        {
            SceneManager.LoadScene(3);
        }

        if (LevelsIndex == 1)
        {
            SceneManager.LoadScene(4);
        }
    }

    public void BackButton()
    {
        SceneManager.LoadScene(1);
    }
}
