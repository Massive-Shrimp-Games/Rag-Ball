﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

namespace LocalCoop {
    /// <summary>
    /// A manager that can be used to add players without having pre-assigned controlled ID's to the input
    /// </summary>
    public class PlayerManager : MonoBehaviour {

        PlayerIndex controllerID1;
        PlayerIndex controllerID2;
        PlayerIndex controllerID3;
        PlayerIndex controllerID4;
        GamePadState controller1state;
        GamePadState controller2state;
        GamePadState controller3state;
        GamePadState controller4state;

        public GameObject[] players = new GameObject[4];

        //PER PLAYER
        public Animator animator1;
        public Transform rotatePlayer1;
        public Transform pivot1;
        public Animator animator2;
        public Transform rotatePlayer2;
        public Transform pivot2;

        public bool use_X_Input = true;
        public int connectedControllers = 0;   //if this variable changes, we need to call an update on the gamepads

        public static PlayerManager singleton = null;

        void Awake() {
            //Check if instance already exists
            if (singleton == null) {
                //if not, set instance to this
                singleton = this;
            }

            //If instance already exists and it's not this:
            else if (singleton != this) {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
                Destroy(gameObject);
            }
        }

        // Use this for initialization
        void Start() {
            connectedControllers = CheckControllerAmount();
            Assign_X_Input_Controllers();
        }

        void Assign_X_Input_Controllers() {
            for (int i = 0; i < 4; ++i) {
                PlayerIndex controllerID = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(controllerID);
                if (testState.IsConnected) {
                    switch (i) {
                        case 0:
                            controllerID1 = controllerID;
                            controller1state = testState;
                            break;
                        case 1:
                            controllerID2 = controllerID;
                            controller2state = testState;
                            break;
                        case 2:
                            controllerID3 = controllerID;
                            controller3state = testState;
                            break;
                        case 3:
                            controllerID4 = controllerID;
                            controller4state = testState;
                            break;
                        default:
                            break;
                    }

                    Debug.Log(string.Format("GamePad found {0}", controllerID));
                }
            }
        }

        //Checks if the amount of controllers changed when connecting/unplugging new controllers
        int CheckControllerAmount() {
            int amount = 0;

            for (int i = 0; i < 4; ++i) {
                PlayerIndex controllerID = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(controllerID);
                if (testState.IsConnected) {
                    amount++;
                }
            }

            return amount;
        }

        // Update is called once per frame
        void Update() {
            if (use_X_Input) {
                if (connectedControllers != CheckControllerAmount()) {
                    connectedControllers = CheckControllerAmount();
                    print("update controllers");
                    Assign_X_Input_Controllers();
                }

                if (controller1state.IsConnected) {
                    controller1state = GamePad.GetState(controllerID1);
                    if (controller1state.Buttons.Start == ButtonState.Pressed) {
                        print("Controller with ID 0 pressed start");
                        //you can call a function here to instantiate a player and then assign this ID to the player input's script to connect the player to the controller that pressed start for example
                        //you then also need to assign that player input script to one of the X input modules to connect it with unity's input system
                    }
                }

                if (controller2state.IsConnected) {
                    controller2state = GamePad.GetState(controllerID2);
                    if (controller2state.Buttons.Start == ButtonState.Pressed) {
                        print("Controller with ID 1 pressed start");
                    }
                }

                if (controller3state.IsConnected) {
                    controller3state = GamePad.GetState(controllerID3);
                    if (controller3state.Buttons.Start == ButtonState.Pressed) {
                        print("Controller with ID 2 pressed start");
                    }
                }

                if (controller4state.IsConnected) {
                    controller4state = GamePad.GetState(controllerID4);
                    if (controller4state.Buttons.Start == ButtonState.Pressed) {
                        print("Controller with ID 3 pressed start");
                    }
                }

                //vvv
                //Player 1 Movement (FIX LATER)
                float H = controller1state.ThumbSticks.Left.X + controller1state.ThumbSticks.Right.X;
                float V = controller1state.ThumbSticks.Left.Y + controller1state.ThumbSticks.Right.Y;

                Vector3 Movement = new Vector3();
                Movement.Set(H, 0f, V);
                Movement = Movement.normalized * 2 * Time.deltaTime;
                //players[0].GetComponent<Rigidbody>().MovePosition(players[0].GetComponent<Transform>().position + Movement);
                players[0].transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(Movement * 1000f);

                float horizontalSpeed = .02f;
                //Debug.Log(players[0].transform.forward.x + ", " + Movement.x);
                if (players[0].transform.forward.x < Movement.x)
                {
                    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -H * horizontalSpeed / Time.deltaTime);
                }
                else
                {
                    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, H * horizontalSpeed / Time.deltaTime);
                }

                if (Movement.magnitude >= 0.03)
                {
                    animator1.Play("Walk");
                }
                else
                {
                    animator1.Play("Idle");
                }

/*
                float speed = 5f;
                float step = speed * Time.deltaTime;
                Vector3 newDir = Vector3.RotateTowards(players[0].transform.forward.normalized, Movement.normalized, step, 0.0f);
                Debug.DrawRay(players[0].transform.position, newDir, Color.red);
                players[0].transform.Find("Player").transform.rotation = Quaternion.LookRotation(newDir);
*/
/*               
                var lookat = Movement;
                lookat.z = 0;
                if (lookat.magnitude > 0)
                {
                    players[0].transform.Find("Player").transform.LookAt(players[0].transform.Find("Player").transform.position + lookat, players[0].transform.Find("Player").transform.forward);
                }
*/
/*
                if (players[0].transform.forward.x < Movement.x)
                {
                    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
                }
                else
                {
                    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
                }
*/


                //Player 2 Movement (FIX LATER)
                H = controller2state.ThumbSticks.Left.X + controller2state.ThumbSticks.Right.X;
                V = controller2state.ThumbSticks.Left.Y + controller2state.ThumbSticks.Right.Y;

                Movement = new Vector3();
                Movement.Set(H, 0f, V);
                Movement = Movement.normalized * 2 * Time.deltaTime;
                //players[1].GetComponent<Rigidbody>().MovePosition(players[1].GetComponent<Transform>().position + Movement);
                players[1].transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(Movement * 1000f);

                if (players[1].transform.forward.x < Movement.x)
                {
                    rotatePlayer2.RotateAround(pivot2.position, Vector3.up, -H * horizontalSpeed / Time.deltaTime);
                }
                else
                {
                    rotatePlayer2.RotateAround(pivot2.position, Vector3.up, H * horizontalSpeed / Time.deltaTime);
                }

                if (Movement.magnitude >= 0.03)
                {
                    animator2.Play("Walk");
                }
                else
                {
                    animator2.Play("Idle");
                }

                if (controller1state.IsConnected) {
                    controller1state = GamePad.GetState(controllerID1);
                    if (controller1state.Buttons.A == ButtonState.Pressed) {
                        //players[0].GetComponent<Rigidbody>().AddForce(players[0].GetComponent<Transform>().up * 10);
                        animator1.Play("JumpHold");
                    }
                }

                if (controller2state.IsConnected) {
                    controller2state = GamePad.GetState(controllerID2);
                    if (controller2state.Buttons.A == ButtonState.Pressed) {
                        animator2.Play("JumpHold");
                    }
                }
                //^^^

            }
            else {
                //join game
                if (Input.GetButtonDown("Start1")) {
                    print("start1");
                }
                if (Input.GetButtonDown("Start2")) {
                    print("Start2");
                }
                if (Input.GetButtonDown("Start3")) {
                    print("Start3");
                }
                if (Input.GetButtonDown("Start4")) {
                    print("Start4");
                }
            }
        }
    }
}