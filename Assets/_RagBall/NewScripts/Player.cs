using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Player : MonoBehaviour
{
    GamePadState gamePadState;
    public int playerNumber;
    public float playerSpeed;

    private GameObject hips;
    private Animator animator;

    [SerializeField] private Transform grabPos; // Set in editor

    // Start is called before the first frame update
    void Start()
    {
        gamePadState = GamePad.GetState((PlayerIndex)playerNumber);

        hips = transform.GetChild(0).GetChild(0).gameObject; //set reference to player's hips
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
    }

    // Update is called once per frame
    void Update()
    {
        gamePadState = GamePad.GetState((PlayerIndex)playerNumber);
        Move();
        if (gamePadState.Buttons.B == ButtonState.Pressed){
            Dash(); 
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(gamePadState.ThumbSticks.Left.X + gamePadState.ThumbSticks.Right.X, 0f,
            gamePadState.ThumbSticks.Left.Y + gamePadState.ThumbSticks.Right.Y);
        movement = movement.normalized * 2 * Time.deltaTime;
        hips.GetComponent<Rigidbody>().AddForce(movement * playerSpeed);

        if (movement != Vector3.zero)
        {
            hips.transform.forward = movement;
        }

        if (movement.magnitude >= 0.03)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Idle");
        }
    }

    void Dash(){
        Vector3 boostDir = hips.transform.forward;
        hips.GetComponent<Rigidbody>().AddForce(boostDir * 2000f);
    }

    void Grab(){

    }

    void Jump(){
        
    }
}
