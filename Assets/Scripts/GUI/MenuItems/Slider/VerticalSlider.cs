using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class VerticalSlider : Slider
{
    public override MenuItem Navigate(InputValue inputValue)
    {
        Vector2 move = inputValue.Get<Vector2>();
        if (move.y > .5f)
        {
            Increment(inputValue);
            return this;
        }
        else if (move.y < -.5f)
        {
            Decrement(inputValue);
            return this;
        }
        else if (move.x < -.5f)
        {
            return Left;
        }
        else if (move.x > .5f)
        {
            return Right;
        }
        else
        {
            return this;
        }
    }
}
