using UnityEngine;
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
    public event InputEventHandler _OnStaggerSelf;  // Remove this
    public event InputEventHandler _OnStart;
    public event InputEventHandler _OnNavigate;
    public event InputEventHandler _OnConfirm;
    public event InputEventHandler _OnReturn;

    private void OnMove(InputValue inputValue)
    {
        _OnMove?.Invoke(inputValue);
    }

    private void OnJump(InputValue inputValue)
    {
        _OnJump?.Invoke(inputValue);
    }

    private void OnDash(InputValue inputValue)
    {
        _OnDash?.Invoke(inputValue);
    }

    private void OnGrabDrop(InputValue inputValue)
    {
        _OnGrabDrop?.Invoke(inputValue);
    }

    private void OnPause(InputValue inputValue)
    {
        _OnPause?.Invoke(inputValue);
    }

    private void OnArcThrow(InputValue inputValue)
    {
        _OnArcThrow?.Invoke(inputValue);
    }

    private void OnDirectThrow(InputValue inputValue)
    {
        _OnDirectThrow?.Invoke(inputValue);
    }

    private void OnStaggerSelf(InputValue inputValue)
    {
        _OnStaggerSelf?.Invoke(inputValue);
    }

    private void OnStart(InputValue inputValue)
    {
        _OnStart?.Invoke(inputValue);
    }

    private void OnNavigate(InputValue inputValue)
    {
        _OnNavigate?.Invoke(inputValue);
    }

    private void OnConfirm(InputValue inputValue)
    {
        _OnConfirm?.Invoke(inputValue);
    }

    private void OnReturn(InputValue inputValue)
    {
        _OnReturn?.Invoke(inputValue);
    }
}
