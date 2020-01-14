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

    private Rigidbody hipsRigidBody; 

    [SerializeField] private Transform grabPos; // Set in editor

    // Start is called before the first frame update
    void Start()
    {
        gamePadState = GamePad.GetState((PlayerIndex)playerNumber);

        hips = transform.GetChild(0).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
    }

    // Update is called once per frame
    void Update()
    {
        gamePadState = GamePad.GetState((PlayerIndex)playerNumber);
        Move();
        if (gamePadState.Buttons.B == ButtonState.Pressed)
        {
            Dash(); 
        }
        if (gamePadState.Buttons.A == ButtonState.Pressed)
        {
            print("A was pressed");
            Jump();
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
        bool LeftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool RightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        if(LeftFoot && RightFoot)
        {
            Vector3 boostDir = hips.transform.up;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * 2000f);
        }
    }

    void Stagger(int time){
        hipsRigidBody.constraints = RigidbodyConstraints.None;
        animator.enabled = false;
        Debug.Log("Stagger time");
        waitingForUnstaggerCoroutine(5); 
    }

    void Unstagger(){
        hipsRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator.enabled = true;
        
    }

    private void OnCollisionEnter(Collision other) {
        /*if (other.gameObject.tag == "Stagger"){
            //Debug.Log("Hit a box");
            Stagger(5); 
        }*/
    }

    private IEnumerator waitingForUnstaggerCoroutine(int time){

        yield return new WaitForSeconds (time); 

        Unstagger(); 
    }
}

