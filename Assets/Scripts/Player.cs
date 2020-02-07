using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public delegate void Exert(int player,int stamina);

    public event Exert OnPlayerExertion;
    
    [SerializeField] private float dashForce; // Set in editor
    [SerializeField] private float jumpForce; // Set in editor
    [SerializeField] private float directThrowForce; // Set in editor
    [SerializeField] private float arcThrowForce; // Set in editor


    public TeamColor color;
    
    private Vector3 directThrowForceVel;
    private Vector3 arcThrowForceVel;

    public float playerSpeed;
    public int staggerCharges;
    public int staggerMaxCharge;
    public int staggerDashCharge;
    public int staggerJumpCharge;
    //private int staminaCharges;

    private const int StaminaMaxCharge = 5;  

    private const int StaminaDashCharge = 1; 

    private const int StaminaJumpCharge = 1; 

    private int StaggerTime = 5;

    private int StaminaRechargeTime = 3;  

    private Collider hipsCollider;

    private bool isRecharging;

    private bool hasStartedRecharging;  

    [SerializeField] private CheckGrab grabCheckCollider;   // Set in editor
    [SerializeField] private Transform grabPos; // Set in editor
    [SerializeField] private Transform directThrowDirection;
    [SerializeField] private Transform arcThrowDirection;
    [SerializeField] private GameObject grabbing;

    private GameObject hips;
    private Animator animator;
    //animator.State.name

    private Rigidbody hipsRigidBody;

    public StaggerCheck staggerCheck;

    public int playerNumber;


    private Controller controller;

    //private Vector2 movement;

    void Awake()
    {
        AssignMaterial();
    }
    private void AssignMaterial()
    {
        if(color == TeamColor.Red)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Medium");
        }
        else if (color == TeamColor.Blue)
        {
            transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Medium_Blue");
        }
    }
    private void Update()
    {
        UpdateHeld();
        if (isRecharging == false && hasStartedRecharging == true){
            StartCoroutine(rechargeStamina());
        }
    }

    void Start()
    {
        if (Game.Instance == null) return; // if the preload scene hasn't been loaded
        MapControls();

        staggerMaxCharge = 5;
        staggerCharges = staggerMaxCharge;
        staggerDashCharge = 1;
        staggerJumpCharge = 1;
        //staminaCharges = StaminaMaxCharge;


        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>();

        grabbing = null;
        isRecharging = false; 
        hasStartedRecharging = false; 
    }

    private void OnDestroy()
    {
        UnMapControls();
    }
    
    private void UpdateHeld()
    {
        if (grabbing != null)
        {
            grabbing.GetComponent<Rigidbody>().position = grabPos.position;
        }
    }

    #region Input Mapping
    private void MapControls()
    {
        controller = Game.Instance.Controllers.GetController(playerNumber);
        controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        if (controller != null)
        {
            controller._OnMove += OnMove;
            controller._OnJump += OnJump;
            controller._OnDash += OnDash;
            controller._OnGrabDrop += OnGrabDrop;
            controller._OnPause += OnPause;
            controller._OnArcThrow += OnArcThrow;
            controller._OnDirectThrow += OnDirectThrow;
            controller._OnGoLimp += OnGoLimp;
        }
    }

    private void UnMapControls()
    {
        if (controller != null)
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
    }
    #endregion

    #region Player Abilities
    private void OnMove(InputValue inputValue)
    {
        Vector2 stickDirection = inputValue.Get<Vector2>();
        Vector3 force = new Vector3(stickDirection.x, 0, stickDirection.y) * playerSpeed * Time.deltaTime;
        hipsRigidBody.AddForce(force);
        //Debug.LogFormat("stickDir is {0}", stickDirection);
        if (Mathf.Abs(stickDirection.x) >= 0.1 || Mathf.Abs(stickDirection.y) >= 0.1)
        {
            hips.transform.forward = new Vector3(stickDirection.x, 0, stickDirection.y);
        }
        animator.Play(force.magnitude >= 0.03 ? "Walk" : "Idle");
    }

    private void OnJump(InputValue inputValue)
    {
        bool LeftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool RightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        if (LeftFoot && RightFoot && staggerCharges >= 0)
        {
            Vector3 boostDir = hips.transform.up;
            hipsRigidBody.AddForce(boostDir * jumpForce);
            staggerCharges = staggerCharges - staggerJumpCharge;
            OnPlayerExertion(playerNumber,staggerCharges);
        }
        hasStartedRecharging = true; 
    }

    private void OnDash(InputValue inputValue)
    {
        if (staggerCharges >= staggerDashCharge)
        {
            Vector3 boostDir = hips.transform.forward;
            hipsRigidBody.AddForce(boostDir * dashForce);
            staggerCharges = staggerCharges - staggerDashCharge;
            OnPlayerExertion(playerNumber,staggerCharges);
        }
        hasStartedRecharging = true; 
    }

    private void OnGrabDrop(InputValue inputValue)
    {
        if (grabbing == null) {
            grabbing = grabCheckCollider.FindClosest();
            
            if (grabbing != null)
            {
                grabbing.GetComponent<Rigidbody>().isKinematic = true;
                grabbing.tag = "Grabbed";
                hips.tag = "Grabbing";
            }
        }
        else {
            grabbing.tag = "Grabbable";
            hips.tag = "Grabbable";

            grabbing.GetComponent<Rigidbody>().isKinematic = false;
            grabbing = null;
        }
    }

    private void OnPause(InputValue inputValue)
    {
        Game.Instance.PauseMenu.Pause(playerNumber);
    }

    private void OnArcThrow(InputValue inputValue)
    {
        if (grabbing == null) { return; }

        // Get reference to what we are holding before we release it
        GameObject objectToThrow = grabbing;
        OnGrabDrop(null);

        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        objectToThrow.GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        staggerCharges = staggerCharges - staggerDashCharge;
        OnPlayerExertion(playerNumber,staggerCharges);
        hasStartedRecharging = true; 
    }

    private void OnDirectThrow(InputValue inputValue)
    {
        if (grabbing == null) { return; }
        
        // Get reference to what we are holding before we release it
        GameObject objectToThrow = grabbing;
        grabbing.GetComponent<Rigidbody>().AddForce(directThrowForce * directThrowDirection.forward);
        OnGrabDrop(null);
        
        directThrowForceVel = directThrowForce * directThrowDirection.forward;
        objectToThrow.GetComponent<Rigidbody>().AddForce(directThrowForceVel);
        staggerCharges = staggerCharges - staggerDashCharge;
        OnPlayerExertion(playerNumber,staggerCharges);
        hasStartedRecharging = true; 
    }

    private void OnGoLimp(InputValue inputValue)
    {

    }
    #endregion

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

    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.tag == "Stagger"){
            //Debug.Log("Hit a box");
            Stagger(5); 
        }*/
    }

    private IEnumerator rechargeStamina(){
        yield return new WaitForSeconds (StaminaRechargeTime);
        hasStartedRecharging = true; 
        recharger();
    }

    void recharger()
    {
        if (staggerCharges < staggerMaxCharge)
        {
            staggerCharges++;
            OnPlayerExertion(playerNumber,staggerCharges);
        }
        if (staggerCharges == staggerMaxCharge){
            isRecharging = false; 
            hasStartedRecharging = false; 
        }
        if (isRecharging == true){
            StartCoroutine(rechargeStamina());
        }
    }
    private IEnumerator waitingForUnstaggerCoroutine(int time)
    {

        yield return new WaitForSeconds(time);

        Unstagger();
    }
}

