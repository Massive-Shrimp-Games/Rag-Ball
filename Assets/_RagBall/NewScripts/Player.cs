using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;

public class Player : MonoBehaviour
{
    [SerializeField] private float dashForce; // Set in editor
    [SerializeField] private float jumpForce; // Set in editor

    public float playerSpeed;
    public int staggerCharges;
    public int staggerMaxCharge;
    public int staggerDashCharge;
    public int staggerJumpCharge;
    private int staminaCharges;

    private const int StaminaMaxCharge = 10;  

    private const int StaminaDashCharge = 2; 

    private const int StaminaJumpCharge = 1; 

    private int StaggerTime = 5;

    private int StaminaRechargeTime = 3;  

    private Collider hipsCollider; 

    private GameObject hips;
    private Animator animator;
    //animator.State.name

    private Rigidbody hipsRigidBody;

    public StaggerCheck staggerCheck; 

    [SerializeField] private Transform grabPos; // Set in editor

    // Start is called before the first frame update

    void Awake(){
        
    }
    void Start()
    {
        staggerMaxCharge = 10;
        staggerCharges = staggerMaxCharge;
        staggerDashCharge = 2;
        staggerJumpCharge = 1;
        staminaCharges = StaminaMaxCharge;

        hips = transform.GetChild(0).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>(); 
    }

    public void Move(Vector2 movement)
    {
        hips.GetComponent<Rigidbody>().AddForce(movement * playerSpeed * Time.deltaTime);
    }

    public void Rotate(Vector2 rotate)
    {
        Vector3 newRotation = new Vector3(rotate.y, 0, rotate.x);
        transform.forward = newRotation;
    }

    public void Dash()
    {
        if (staggerCharges >= staggerDashCharge)
        {
            Vector3 boostDir = hips.transform.forward;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * dashForce);
            staggerCharges = staggerCharges - staggerDashCharge;

        }
    }

    public void Grab()
    {

    }

    public void Jump()
    {
        bool LeftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool RightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        if(LeftFoot && RightFoot && staminaCharges >= StaminaJumpCharge)
        {
            Vector3 boostDir = hips.transform.up;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * jumpForce);
            staggerCharges = staggerCharges - staggerJumpCharge; 
        }
    }

    void Stagger(int time)
    {
        hipsRigidBody.constraints = RigidbodyConstraints.None;
        animator.enabled = false;
        Debug.Log("Stagger time");

        waitingForUnstaggerCoroutine(5);
        waitingForUnstaggerCoroutine(StaggerTime); 
    }

    void Unstagger()
    {
        hipsRigidBody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        animator.enabled = true;
    }
    
    void recharger()
    {
        if (staggerCharges < staggerMaxCharge)
        {
            staggerCharges++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.tag == "Stagger"){
            //Debug.Log("Hit a box");
            Stagger(5); 
        }*/
    }
    
    private IEnumerator rechargeStamina(){
        yield return new WaitForSeconds (StaminaRechargeTime);

        recharger();
    }

    private IEnumerator waitingForUnstaggerCoroutine(int time)
    {

        yield return new WaitForSeconds(time);

        Unstagger();
    }
}

