using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public delegate void InputEventHandler(InputValue inputValue);

    public event InputEventHandler _OnMove;
    public event InputEventHandler _OnJump;

    private void OnMove(InputValue inputValue)
    {
        _OnMove(inputValue);
    }

    private void OnJump(InputValue inputValue)
    {
        _OnJump(inputValue);
    }
}
