using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public abstract class Button : MenuItem
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
