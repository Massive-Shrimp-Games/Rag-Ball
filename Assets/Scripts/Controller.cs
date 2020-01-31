﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public delegate void InputEventHandler(InputValue inputValue);

    public event InputEventHandler _OnMove;
    public event InputEventHandler _OnJump;
    public event InputEventHandler _OnDash;
    public event InputEventHandler _OnGrabDrop;
    public event InputEventHandler _OnPause;
    public event InputEventHandler _OnArcThrow;
    public event InputEventHandler _OnDirectThrow;
    public event InputEventHandler _OnGoLimp;
    public event InputEventHandler _OnStart;
    public event InputEventHandler _OnNavigate;
    public event InputEventHandler _OnConfirm;
    public event InputEventHandler _OnReturn;

    private void OnMove(InputValue inputValue)
    {
        _OnMove(inputValue);
    }

    private void OnJump(InputValue inputValue)
    {
        _OnJump(inputValue);
    }

    private void OnDash(InputValue inputValue)
    {
        _OnDash(inputValue);
    }

    private void OnGrabDrop(InputValue inputValue)
    {
        _OnGrabDrop(inputValue);
    }

    private void OnPause(InputValue inputValue)
    {
        _OnPause(inputValue);
    }

    private void OnArcThrow(InputValue inputValue)
    {
        _OnArcThrow(inputValue);
    }

    private void OnDirectThrow(InputValue inputValue)
    {
        _OnDirectThrow(inputValue);
    }

    private void OnGoLimp(InputValue inputValue)
    {
        _OnGoLimp(inputValue);
    }

    private void OnStart(InputValue inputValue)
    {
        _OnStart(inputValue);
    }

    private void OnNavigate(InputValue inputValue)
    {
        _OnNavigate(inputValue);
    }

    private void OnConfirm(InputValue inputValue)
    {
        _OnConfirm(inputValue);
    }

    private void OnReturn(InputValue inputValue)
    {
        _OnReturn(inputValue);
    }
}
