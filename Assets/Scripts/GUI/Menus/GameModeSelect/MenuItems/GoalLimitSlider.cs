using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalLimitSlider : HorizontalSlider
{
    [SerializeField] private int maxGoals = 99;

    protected override void Increment(InputValue inputValue)
    {
        if (++GameModeSelect.goalLimit > maxGoals)
            GameModeSelect.goalLimit = 0;
    }

    protected override void Decrement(InputValue inputValue)
    {
        if (--GameModeSelect.goalLimit < 0)
            GameModeSelect.goalLimit = maxGoals;
    }
}
