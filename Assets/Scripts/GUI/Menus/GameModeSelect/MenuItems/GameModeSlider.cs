using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameModeSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        Debug.Log("Increment game mode");
        if ((int)++GameModeSelect.gameMode >= GameMode.Count)
        {
            GameModeSelect.gameMode = 0;
        }
    }

    protected override void Decrement(InputValue inputValue)
    {
        Debug.Log("Decrement game mode");
        if ((int)--GameModeSelect.gameMode < 0)
        {
            GameModeSelect.gameMode = (GameMode.Mode)GameMode.Count - 1;
        }
    }
}
