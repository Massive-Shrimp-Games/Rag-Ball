//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.InputSystem;

//// ControllerClass
//// Controller[] controllers;
////
////
//// menu system
//// new Menu(controllers)
//// new GameRagball()
//// new Player(controller[0])
//// new Player(controller[1])
////
//// class Player
//// PauseEvent pe; (Scriptable Object)
//// private Controller controller;
//// Awake()
//// controller.Movement.performed += ctx => Move();
//// controller.Pause.performed += ctx => Pause();
//// Pause()
//// pe.emit(controller);
//// new PauseMenu(controller);
//// 
//// controllers[1].CharacterSelect.performed += ctx => new Player(controller)

//public class InputController : MonoBehaviour
//{
//    [SerializeField] private InputAction moveInput;
//    [SerializeField] private InputAction dashInput;
//    [SerializeField] private InputAction jumpInput;
//    [SerializeField] private InputAction grabInput;
//    [SerializeField] private InputAction rotateInput;

//    [SerializeField] private Player player;

//    private void Awake()
//    {
//        moveInput.performed += context => MoveInputOcurred(context.ReadValue<Vector2>());
//        moveInput.canceled += context => MoveInputCanceled();

//        rotateInput.performed += context => RotateInputOcurred(context.ReadValue<Vector2>());
//        rotateInput.canceled += context => RotateInputCanceled();

//        dashInput.performed += context => DashInputOcurred();
//        dashInput.canceled += context => DashInputCanceled();

//        jumpInput.performed += context => JumpInputOcurred();
//        jumpInput.canceled += context => JumpInputCanceled();

//        grabInput.performed += context => GrabInputOcurred();
//        grabInput.canceled += context => GrabInputCanceled();
//    }

//    private void MoveInputOcurred(Vector2 move)
//    {
//        player.Move(move);
//    }

//    private void MoveInputCanceled()
//    {
//        player.Move(Vector2.zero);
//    }

//    private void RotateInputOcurred(Vector2 rotate)
//    {
//        print("rotate");
//        player.Rotate(rotate);
//    }

//    private void RotateInputCanceled()
//    {
//        // Do nothing, perhaps this function doesn't need to be called at all
//    }

//    private void DashInputOcurred()
//    {
//        player.Dash();
//    }

//    private void DashInputCanceled()
//    {

//    }

//    private void JumpInputOcurred()
//    {
//        player.Jump();
//    }

//    private void JumpInputCanceled()
//    {
//        // Do nothing, perhaps this function doesn't need to be called at all
//    }

//    private void GrabInputOcurred()
//    {
//        player.Grab();
//    }

//    private void GrabInputCanceled()
//    {
//        // Do nothing, perhaps this function doesn't need to be called at all
//    }

//    private void OnEnable()
//    {
//        moveInput.Enable();
//        rotateInput.Enable();
//        dashInput.Enable();
//        jumpInput.Enable();
//        grabInput.Enable();
//    }

//    private void OnDisable()
//    {
//        moveInput.Disable();
//        rotateInput.Disable();
//        dashInput.Disable();
//        jumpInput.Disable();
//        grabInput.Disable();
//    }
//}
