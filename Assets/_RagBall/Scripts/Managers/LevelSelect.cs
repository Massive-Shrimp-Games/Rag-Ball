using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSelect : MonoBehaviour
{
    public RawImage[] GameModes;
    private int GameModeIndex;
    public RawImage[] Levels;
    private int LevelsIndex;
    public RawImage PipeMovementCross;
    public RawImage SlippyCross;
    public RawImage NoWallsCross;
    public RawImage GoalsOn;
    public RawImage GoalsOff;
    public RawImage TimerOn;
    public RawImage TimerOff;
    public GameObject GoalsTMP;
    public GameObject TimerTMP;
    public string GoalsCountText;
    public string TimerCountText;
    public int GoalsCount = 0;
    public int TimerCount = 0;


    void Awake()
    {
        GameModeIndex = 0;
        LevelsIndex = 0;
        PipeMovementCross.enabled = false;
        SlippyCross.enabled = false;
        NoWallsCross.enabled = false;

        GoalsOn.enabled = false;
        TimerOn.enabled = false;

        CustomizationManager.CM.PipeMovement = true;
        CustomizationManager.CM.WallsActive = true;
        CustomizationManager.CM.Slippy = true;
        CustomizationManager.CM.GoalsActive = false;
        CustomizationManager.CM.TimerActive = false;
        
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

        CustomizationManager.CM.GoalsMax = GoalsCount;
        CustomizationManager.CM.TimerMax = TimerCount;

        GoalsCountText = "" + GoalsCount;
        GoalsTMP.GetComponent<TMP_Text>().text = GoalsCountText;

        TimerCountText = "" + TimerCount;
        TimerTMP.GetComponent<TMP_Text>().text = TimerCountText;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(3);
        }

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

    public void TimeActive()
    {
        if (TimerOn.enabled == false)
        {
            TimerOff.enabled = false;
            TimerOn.enabled = true;
            CustomizationManager.CM.TimerActive = true;
        }

        else if (TimerOn.enabled == true)
        {
            TimerOff.enabled = true;
            TimerOn.enabled = false;
            CustomizationManager.CM.TimerActive = false;
        }
    }

    public void GoalsActive()
    {
        if (GoalsOn.enabled == false)
        {
            GoalsOff.enabled = false;
            GoalsOn.enabled = true;
            CustomizationManager.CM.GoalsActive = true;
        }

        else if (GoalsOn.enabled == true)
        {
            GoalsOff.enabled = true;
            GoalsOn.enabled = false;
            CustomizationManager.CM.GoalsActive = false;
        }
    }

    public void addTime()
    {
        TimerCount += 1;

        if (TimerCount >= 10)
        {
            TimerCount = 10;
        }
    }

    public void subTime()
    {
        TimerCount -= 1;

        if (TimerCount <= 0)
        {
            TimerCount = 0;
        }
    }

    public void addScore()
    {
        GoalsCount += 1;
        
        if (GoalsCount >= 25)
        {
            GoalsCount = 25;
        }
    }

    public void subScore()
    {
        GoalsCount -= 1;
        
        if (GoalsCount <= 0)
        {
            GoalsCount = 0;
        }
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
