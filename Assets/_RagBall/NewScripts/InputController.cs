using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction moveInput;
    [SerializeField] private InputAction dashInput;
    [SerializeField] private InputAction jumpInput;
    [SerializeField] private InputAction grabInput;
    [SerializeField] private InputAction straightThrowInput;
    [SerializeField] private InputAction arcThrowInput;

    [SerializeField] private Player player;

    private void Awake()
    {
        moveInput.performed += context => MoveInputOcurred(context.ReadValue<Vector2>());
        moveInput.canceled += context => MoveInputCanceled();

        dashInput.performed += context => DashInputOcurred();

        jumpInput.performed += context => JumpInputOcurred();
        jumpInput.canceled += context => JumpInputCanceled();

        grabInput.performed += context => GrabInputOcurred();

        straightThrowInput.performed += context => StraightThrowOcurred();
        straightThrowInput.performed += context => StraightThrowCanceled();

        arcThrowInput.performed += context => ArcThrowOcurred();
        arcThrowInput.performed += context => ArcThrowCanceled();
    }

    private void MoveInputOcurred(Vector2 move)
    {
        player.Move(move);
    }

    private void MoveInputCanceled()
    {
        player.Move(Vector2.zero);
    }

    private void DashInputOcurred()
    {
        player.Dash();
    }


    private void JumpInputOcurred()
    {
        player.Jump();
    }

    private void JumpInputCanceled()
    {
        // Do nothing, perhaps this function doesn't need to be called at all
    }

    private void GrabInputOcurred()
    {
        player.GrabDrop();
    }
    
    private void OnEnable()
    {
        moveInput.Enable();
        rotateInput.Enable();
        dashInput.Enable();
        jumpInput.Enable();
        grabInput.Enable();
        straightThrowInput.Enable();
        arcThrowInput.Enable();
    }

    private void OnDisable()
    {
        moveInput.Disable();
        rotateInput.Disable();
        dashInput.Disable();
        jumpInput.Disable();
        grabInput.Disable();
        straightThrowInput.Disable();
        arcThrowInput.Disable();
    }
}
