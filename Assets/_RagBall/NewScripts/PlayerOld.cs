using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class PlayerOld : MonoBehaviour
{
    GamePadState gamePadState;
    public int playerNumber;
    public float playerSpeed;

    private int staminaCharges;

    private const int StaminaMaxCharge = 10;  

    private const int StaminaDashCharge = 2; 

    private const int StaminaJumpCharge = 1; 

    private int StaggerTime = 5;

    private int StaminaRechargeTime = 3;  

    private Collider hipsCollider; 

    private bool yPressed = false; 

    private GameObject hips;
    private Animator animator;
    //animator.State.name

    private Rigidbody hipsRigidBody; 

    public StaggerCheck staggerCheck; 

    [SerializeField] private Transform grabPos; // Set in editor

    // Start is called before the first frame update
    void Start()
    {
        gamePadState = GamePad.GetState((PlayerIndex)playerNumber);
        staminaCharges = StaminaMaxCharge;  
        hips = transform.GetChild(0).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>();

        TimeTicker.OnTick += delegate (object sender, TimeTicker.OnTickEventArgs e)
        {
            recharger();
        };

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
        if (gamePadState.Buttons.Y == ButtonState.Pressed)
        {
            Ragdoll(); 
        }
        //Debug.Log(staminaCharges); 
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

    void Ragdoll(){

        Debug.Log("Y Button was pressed!");
        Stagger(5);
    }
    void Dash(){
        Vector3 boostDir = hips.transform.forward;
        hips.GetComponent<Rigidbody>().AddForce(boostDir * 2000f);
        staminaCharges = staminaCharges - StaminaDashCharge;
        /*
        Will rework stamina during next meeting
        if (staminaCharges >= StaminaDashCharge){
            Vector3 boostDir = hips.transform.forward;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * 2000f);
            staminaCharges = staminaCharges - StaminaDashCharge; 
        }
        */
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
            staminaCharges = staminaCharges - StaminaJumpCharge; 
        }
        /*
        if(LeftFoot && RightFoot && staminaCharges >= StaminaJumpCharge)
        {
            Vector3 boostDir = hips.transform.up;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * 2000f);
            staminaCharges = staminaCharges - StaminaJumpCharge; 
        }
        */
    }

    void Stagger(int time){
        Debug.Log("Stagger time");
        if(yPressed == false){
            hipsRigidBody.constraints = RigidbodyConstraints.None;
            animator.enabled = false;
        }
        else{
            hipsRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            animator.enabled = true;
        }

        //Need to debug
        //Debug.Log("Stagger time");
        //waitingForUnstaggerCoroutine(StaggerTime); 
    }

    void Unstagger(){
        hipsRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator.enabled = true;
        Debug.Log("Unstagger time");
    }

    void recharger(){
        print("Recharger callled");
        if (staminaCharges < StaminaMaxCharge){
            //Changing until scene works better.
            staminaCharges = StaminaMaxCharge; 
        }
    }

    private void OnCollisionEnter(Collision other) {
        /*if (other.gameObject.tag == "Stagger"){
            //Debug.Log("Hit a box");
            Stagger(5); 
        }*/
    }

    private IEnumerator rechargeStamina(){
        yield return new WaitForSeconds (StaminaRechargeTime);

        recharger(); 
    }
    private IEnumerator waitingForUnstaggerCoroutine(int time){

        yield return new WaitForSeconds (time); 
        Debug.Log("HI, Im waiting");
        Unstagger(); 
    }
}