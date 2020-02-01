using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class HorizontalSlider : Slider
{
    public override MenuItem Navigate(InputValue inputValue)
    {
        Vector2 move = inputValue.Get<Vector2>();
        if (move.y > .5f)
        {
            return Up;
        }
        else if (move.y < -.5f)
        {
            return Down;
        }
        else if (move.x < -.5f)
        {
            Decrement(inputValue);
            return this;
        }
        else if (move.x > .5f)
        {
            Increment(inputValue);
            return this;
        }
        else
        {
            return this;
        }
    }
}
