using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.InputSystem;

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

    public int playerNumber;

    [SerializeField] private Transform grabPos; // Set in editor

    private Controller controller;

    //private Vector2 movement;

    // Start is called before the first frame update

    void Awake()
    {
        //movement = Vector2.zero;
    }

    private void Update()
    {
        //movement = Vector2.zero;
    }

    void Start()
    {
        controller = Controllers.Instance.GetController(playerNumber);
        controller._OnMove += OnMove;
        controller._OnJump += OnJump;
        controller._OnDash += OnDash;
        controller._OnGrabDrop += OnGrabDrop;
        controller._OnPause += OnPause;
        controller._OnArcThrow += OnArcThrow;
        controller._OnDirectThrow += OnDirectThrow;
        controller._OnGoLimp += OnGoLimp;

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

    private void OnDestroy()
    {
        controller._OnMove -= OnMove;
        controller._OnJump -= OnJump;
        controller._OnDash -= OnDash;
        controller._OnGrabDrop -= OnGrabDrop;
        controller._OnPause -= OnPause;
        controller._OnArcThrow -= OnArcThrow;
        controller._OnDirectThrow -= OnDirectThrow;
        controller._OnGoLimp -= OnGoLimp;
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 stickDirection = inputValue.Get<Vector2>();
        Vector3 force = new Vector3(stickDirection.x, 0, stickDirection.y) * playerSpeed * Time.deltaTime;
        hips.GetComponent<Rigidbody>().AddForce(force);
        hips.transform.forward = new Vector3(stickDirection.x, 0, stickDirection.y);
        animator.Play(force.magnitude >= 0.03 ? "Walk" : "Idle");
    }

    private void OnJump(InputValue inputValue)
    {
        bool LeftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool RightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        if (LeftFoot && RightFoot && staminaCharges >= StaminaJumpCharge)
        {
            Vector3 boostDir = hips.transform.up;
            hips.GetComponent<Rigidbody>().AddForce(boostDir * jumpForce);
            staggerCharges = staggerCharges - staggerJumpCharge;
        }
    }

    private void OnDash(InputValue inputValue)
    {

    }

    private void OnGrabDrop(InputValue inputValue)
    {

    }

    private void OnPause(InputValue inputValue)
    {

    }

    private void OnArcThrow(InputValue inputValue)
    {

    }

    private void OnDirectThrow(InputValue inputValue)
    {

    }

    private void OnGoLimp(InputValue inputValue)
    {

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

