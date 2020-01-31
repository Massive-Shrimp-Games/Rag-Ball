using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeLimitSlider : HorizontalSlider
{
    public int maxTimeLimit = 99;
    protected override void Increment(InputValue inputValue)
    {
        if (++GameModeSelect.timeLimit > maxTimeLimit)
            GameModeSelect.timeLimit = 0;
    }

    protected override void Decrement(InputValue inputValue)
    {
        if (--GameModeSelect.timeLimit < 0)
            GameModeSelect.timeLimit = maxTimeLimit;
    }
}
