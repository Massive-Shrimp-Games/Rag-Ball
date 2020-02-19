﻿using System.Collections;
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
    [SerializeField] private int staggerTime; // Set in editor

    //public TeamColor color;
    
    private Vector3 directThrowForceVel;
    private Vector3 arcThrowForceVel;

    public float playerSpeed;
    public int staggerCharges;
    public int staggerMaxCharge;
    public int staggerDashCharge;
    public int staggerJumpCharge;
    //private int staminaCharges;

    private bool canJump;
    public bool dashing;    // Protect this with a Getter
    [SerializeField] private float dashVelocityMinimum;
    [SerializeField] private StaggerCheck staggerCheck;

    private const int StaminaMaxCharge = 5;  

    private const int StaminaDashCharge = 1; 

    private const int StaminaJumpCharge = 1; 

    private int StaminaRechargeTime = 3;  

    private Collider hipsCollider;

    private bool isRecharging;

    private bool hasStartedRecharging;  
    private SpriteRenderer sp_cursor; 

    [SerializeField] private CheckGrab grabCheckCollider;   // Set in editor
    [SerializeField] private Transform grabPos; // Set in editor
    [SerializeField] private Transform directThrowDirection;
    [SerializeField] private Transform arcThrowDirection;
    [SerializeField] private GameObject staggerStars;
    private TrailRenderer trailRenderer;

    private GameObject grabbing;

    private GameObject hips;
    private Animator animator;
    private Rigidbody hipsRigidBody;

    public int playerNumber = 0;
    public Size size;
    public TeamColor color;
    private Controller controller;

    void Awake()
    {
        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>();
        trailRenderer = hips.GetComponent<TrailRenderer>();

        AssignMaterial();
        staggerCheck.OnStaggerSelf += StaggerSelf;
    }

    private void AssignMaterial()
    {
        if(color == TeamColor.Red)
        {
            if(size == Size.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Small");
                
            } else if (size == Size.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Medium");
            } else if (size == Size.Large)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Large");
            }
            transform.Find("Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Character_DirectionalCircle_Red_01");
        }
        else if (color == TeamColor.Blue)
        {
            if(size == Size.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Small");
            } else if (size == Size.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Medium");
            } else if (size == Size.Large)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Large");
            }
            transform.Find("Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Character_DirectionalCircle_Blue_01");
        }
    }
    private void Update()
    {
        UpdateHeld();
        bool leftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool rightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        canJump = leftFoot || rightFoot;

        staggerStars.transform.Rotate(staggerStars.transform.up, 1f);
        if (isRecharging == false && hasStartedRecharging == true){
            StartCoroutine(rechargeStamina());
        }

        dashing = hipsRigidBody.velocity.magnitude > dashVelocityMinimum;
        staggerStars.transform.Rotate(staggerStars.transform.up, 1f);

        if (hipsRigidBody.velocity.magnitude > 6f)
        {
            trailRenderer.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
        }
    }
    void Start()
    {
        canJump = false;

        if (Game.Instance == null) return; // if the preload scene hasn't been loaded
        MapControls();

        staggerMaxCharge = 5;
        staggerCharges = staggerMaxCharge;
        staggerDashCharge = 1;
        staggerJumpCharge = 1;
        //staminaCharges = StaminaMaxCharge;


        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.GetComponent<Collider>();

        trailRenderer = transform.GetChild(1).GetChild(0).GetComponent<TrailRenderer>();

        
        dashing = false;
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

        if (hipsRigidBody.velocity.magnitude > dashVelocityMinimum)
        {
            //trailRenderer.enabled = true;
        }
        else
        {
            //trailRenderer.enabled = false;
        }
    }

    #region Input Mapping
    private void MapControls()
    {
        controller = Game.Instance.Controllers.GetController(playerNumber);
        if (controller != null)
        {
            controller._OnMove += OnMove;
            controller._OnJump += OnJump;
            controller._OnDash += OnDash;
            controller._OnGrabDrop += OnGrabDrop;
            controller._OnPause += OnPause;
            controller._OnArcThrow += OnArcThrow;
            controller._OnDirectThrow += OnDirectThrow;
            controller._OnStaggerSelf += OnStaggerSelf;
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
            controller._OnStaggerSelf -= OnStaggerSelf;
        }
    }
    #endregion

    #region Player Abilities
    private void OnMove(InputValue inputValue)
    {
        if (hips.tag != "Grabbed"){
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
    }

    private void OnJump(InputValue inputValue)
    {
        if (canJump && staggerCharges >= 0 && hips.tag != "Grabbed")
        {
            Vector3 boostDir = hips.transform.up;
            hipsRigidBody.AddForce(boostDir * jumpForce);
            staggerCharges = staggerCharges - staggerJumpCharge;
            OnPlayerExertion(playerNumber,staggerCharges);
            if(!hasStartedRecharging)
            {
                StartCoroutine(rechargeStamina());
            }
        }
    }

    private void OnDash(InputValue inputValue)
    {
        if (staggerCharges >= staggerDashCharge && hips.tag != "Grabbed")
        {
            Vector3 boostDir = hips.transform.forward;
            hipsRigidBody.AddForce(boostDir * dashForce);
            staggerCharges = staggerCharges - staggerDashCharge;
            OnPlayerExertion(playerNumber,staggerCharges);
            if(!hasStartedRecharging)
            {
                StartCoroutine(rechargeStamina());
            }
        }
    }

    private void OnGrabDrop(InputValue inputValue)
    {
        if (grabbing == null) {
            if (hips.tag == "Grabbable"){
                grabbing = grabCheckCollider.FindClosest();
            }
            if (grabbing != null)
            {
                grabbing.GetComponent<Rigidbody>().isKinematic = true;
                grabbing.tag = "Grabbed";
                //grabbing.GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().GetComponentInParent<Player>().;
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
    }

    private void OnStaggerSelf(InputValue inputValue)
    {
        staggerStars.SetActive(true);
        StartCoroutine("StaggerSelf");
        if (grabbing != null)
        {
            OnGrabDrop(null);
        }
    }
    #endregion

    private void StaggerSelf(bool enemyDashing, TeamColor enemyColor)
    {
        if (enemyDashing == true && enemyColor != color)
        {
            hipsRigidBody.isKinematic = true;
            animator.enabled = false;
            staggerStars.SetActive(true);
            if (grabbing) { OnGrabDrop(null); }
            StartCoroutine("UnStagger");
        }
    }

    private IEnumerator UnStagger()
    {
        yield return new WaitForSeconds(staggerTime);
        hipsRigidBody.isKinematic = false;
        animator.enabled = true;
        staggerStars.SetActive(false);
    }

    private IEnumerator rechargeStamina(){
        hasStartedRecharging = true;
        yield return new WaitForSeconds (StaminaRechargeTime);
        recharger();
        if(staggerCharges < staggerMaxCharge)
        {
            StartCoroutine(rechargeStamina());
        }
        else
        {
            hasStartedRecharging = false;
        }
    }

    void recharger()
    {
        if (staggerCharges < staggerMaxCharge)
        {
            staggerCharges++;
            OnPlayerExertion(playerNumber,staggerCharges);
        }
        
    }
    private IEnumerator waitingForUnstaggerCoroutine(int time)
    {

        yield return new WaitForSeconds(time);

        UnStagger();
    }

    public void ResetVelocity()
    {
        hipsRigidBody.velocity = Vector3.zero;
    }

    public GameObject getHips(){
        return hips; 
    }
}

