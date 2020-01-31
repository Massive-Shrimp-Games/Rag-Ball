using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Slider : MenuItem
{
    public override void Select(Cursor cursor) { }
    protected abstract void Increment(InputValue inputValue);
    protected abstract void Decrement(InputValue inputValue);
}
