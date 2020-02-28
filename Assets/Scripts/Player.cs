﻿

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// Makes this object a RagBall Player.
/// Allows: Staggering, Moving, Dashing.
/// </summary>
public class Player : MonoBehaviour
{

    public delegate void Exert(int player, int stamina);

    public event Exert OnPlayerExertion;

    [SerializeField] private float dashForce; // Set in editor
    [SerializeField] private float jumpForce; // Set in editor
    [SerializeField] private float directThrowForce; // Set in editor
    [SerializeField] private float arcThrowForce; // Set in editor
    [SerializeField] private int staggerTime; // Set in editor

    private Vector3 directThrowForceVel;
    private Vector3 arcThrowForceVel;

    public float playerSpeed;
    public int staggerCharges;
    public int staggerMaxCharge;
    public int staggerDashCharge;
    public int staggerJumpCharge;
    //private int staminaCharges;


    // Airborne Variables
    // Set isThrown to TRUE on any player when they are thrown -> access the grabbed objects isThrown variable
    // Set canJump to FALSE on any player when they are thrown
    public bool isThrown = false;
    public bool canJump = false;                // Can the Player jump - the robust value we use for decision making
    public bool isDropped = false;              // Stupid Extra Variable grrrrrrrrr


    // Stagger Variables
    public bool dashing;   // Protect this with a Getter
    public bool staggered = false;
    [SerializeField] private float dashVelocityMinimum;
    [SerializeField] private StaggerCheck staggerCheck;


    // Stamina
    private const int StaminaMaxCharge = 5;
    private const int StaminaDashCharge = 1;
    private const int StaminaJumpCharge = 1;
    private float StaminaRechargeTime = 1.5f;




    private Collider hipsCollider;

    private bool isRecharging;

    private bool hasStartedRecharging;
    private SpriteRenderer sp_cursor;

    [SerializeField] private CheckGrab grabCheckCollider;   // Set in editor
    [SerializeField] private Transform grabPos; // Set in editor
    [SerializeField] private Transform directThrowDirection;
    [SerializeField] private Transform arcThrowDirection;

    [SerializeField] private GameObject grabbing;

    // Instead of this, have a particle handler
    [SerializeField] private GameObject staggerStars;
    [SerializeField] private GameObject collisionTrigger;
    private TrailRenderer trailRenderer;

    private GameObject hips;
    private Animator animator;
    private Rigidbody hipsRigidBody;

    //Used for creating the visualized arc when throwing
    public int lineSegment = 3;
    private LineRenderer lineVisual;
    public LayerMask layer;


    //Jump Variables
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float jumpMultiplier;
    private bool aIsPressed = false;

    private Vector2 movement;

    public int playerNumber = 0;
    public RagdollSize size;
    public TeamColor color;
    private Controller controller;


    /// <summary>
    /// Set Initial Values and References for the player's Systems on Spawn
    /// </summary>
    void Start()
    {
        canJump = false;

        // Duplicate Case
        if (Game.Instance == null) return;      // if the preload scene hasn't been loaded
        MapControls();                          // if the preload scene HAS loaded, get the controls


        // Stamina Setup
        staggerMaxCharge = 5;
        staggerCharges = staggerMaxCharge;      // Max out the player staggers on Spawn
        staggerDashCharge = 1;
        staggerJumpCharge = 1;
        //staminaCharges = StaminaMaxCharge;


        // Body Setup
        hips = transform.GetChild(1).GetChild(0).gameObject;                                //set reference to player's hips
        hipsRigidBody = hips.GetComponent<Rigidbody>();                                     //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>();        //set reference to player's animator
        hipsCollider = hips.GetComponent<Collider>();


        // Special Effects
        trailRenderer = transform.GetChild(1).GetChild(0).GetComponent<TrailRenderer>();


        dashing = false;
        grabbing = null;
        isRecharging = false;               // Player starts fully charged
        hasStartedRecharging = false;       // Player starts fully charged
    }


    /// <summary>
    /// Before putting the player on screen, give them a team mesh.
    /// Also assign their body parts and statuses.
    /// </summary>
    void Awake()
    {
        // Body Parts
        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>();

        // Special Effects
        trailRenderer = hips.GetComponent<TrailRenderer>();
        lineVisual = hips.transform.parent.parent.GetChild(2).GetChild(1).gameObject.GetComponent<LineRenderer>(); 
        AssignMaterial();

        // Statuses
        staggerCheck.OnStaggerSelf += StaggerSelf;
    }


    /// <summary>
    /// Checks if Jumping, Dashing, Jumping, beingThrown, and oter Active Statuses are in Effect
    /// </summary>
    private void Update()
    {
        UpdateHeld();           // Prevent grabbed objects from falling

        // Update the status of whether the player can jump or not
        bool leftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;     // Need to fetch these objects everytime, for unknown reasons
        bool rightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        canJump = leftFoot || rightFoot;

        // Special Effects
        staggerStars.transform.Rotate(staggerStars.transform.up, 1f);

        // Movement Effects
        Move();                     // ???
        JumpPhysics();              // Apply sharp falling on player
        UpdateThrown();             // Can the player move again/stop being a projectile?

        // Once done recovering, see if player needs more stamina
        if (isRecharging == false && hasStartedRecharging == true){
            StartCoroutine(rechargeStamina());
        }

        // Find the forward direction of the player
        float determinDirection = Vector3.Dot(hipsRigidBody.velocity.normalized, hips.transform.forward);
        float determineMagnitue = hipsRigidBody.velocity.magnitude;

        // Is the player dashing?
        dashing = (hipsRigidBody.velocity.magnitude > dashVelocityMinimum) && (Mathf.Abs(determinDirection) > .5);
        
        // render the Trailing Line
        if (dashing)
        {
            trailRenderer.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
        }
    }


    private void OnDestroy()
    {
        UnMapControls();
    }

    /// <summary>
    /// Assigns the team's Material to the Player's Renderer
    /// </summary>
    private void AssignMaterial()
    {
        if (color == TeamColor.Red)
        {
            if (size == RagdollSize.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Small");

            }
            else if (size == RagdollSize.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Medium");
            }
            else if (size == RagdollSize.Large)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Large");
            }
            transform.Find("Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Character_DirectionalCircle_Red_01");
        }
        else if (color == TeamColor.Blue)
        {
            if (size == RagdollSize.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Small");
            }
            else if (size == RagdollSize.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Medium");
            }
            else if (size == RagdollSize.Large)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Large");
            }
            transform.Find("Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Character_DirectionalCircle_Blue_01");
        }
    }


    /// <summary>
    /// Controls decay of player as they fall, called from UPDATE
    /// ONLY affects players who jump, not those who are thrown
    /// Makes the jumping more snappy
    /// </summary>
    private void JumpPhysics()
    {
        if (!canJump && !isThrown)
        {
            if (hips.GetComponent<Rigidbody>().velocity.y > 0 && aIsPressed)
            {
                hipsRigidBody.velocity += Vector3.up * Physics.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
            }
            else
            {
                hipsRigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    /// <summary>
    /// Checks if the player has landed and stops treating them as a projectile
    /// Also used when a player is dropped
    /// </summary>
    private void UpdateThrown()
    {
        if (canJump && isThrown)                // If player was thrown
        {
            isThrown = false;
            MapControls();
        }
        else if (canJump && isDropped)          // If player was dropped
        {
            isDropped = false;
            MapControls();
        }
    }

    /// <summary>
    /// Set a victim's canJump and isThrown from a 'OnThrow' event
    /// ATTN: Assumes 'grabbing' is NOT NULL
    /// Allows a grabbed object to stun other players when thrown
    /// IS NOT used when you drop a player
    /// </summary>
    private void VictimVariables()
    {
        if (grabbing)
        {
            Player victim = grabbing.GetComponent<BaseObject>().player;
            if (victim == null) return; // This is for throwing non-players
            victim.isThrown = true;
            victim.canJump = false;     // Don't want them getting away now, do we? H AH AH A HA HA AH HA A HA !!!!!
        }
    }

    
    private void UpdateHeld()
    {
        if (grabbing != null)
        {
            BaseObject held = grabbing.GetComponent<BaseObject>();
            if(held != null)
            {
                held.player.getHips().GetComponent<Rigidbody>().position = grabPos.position;
            }
            else
            {
                grabbing.GetComponent<Rigidbody>().position = grabPos.position;
            }
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
            controller._OnJumpRelease += OnJumpRelease;
            controller._OnDash += OnDash;
            controller._OnGrabDrop += OnGrabDrop;
            controller._OnPause += OnPause;
            controller._OnArcThrow += OnArcThrow;
            controller._OnDirectThrow += OnDirectThrow;
            controller._OnHoldArcThrow += OnHoldArcThrow;
            controller._OnHoldDirectThrow += OnHoldDirectThrow;
        }
    }
    private void UnMapControls()
    {
        if (controller != null)
        {
            controller._OnMove -= OnMove;
            controller._OnJump -= OnJump;
            controller._OnJumpRelease -= OnJumpRelease;
            controller._OnDash -= OnDash;
            controller._OnGrabDrop -= OnGrabDrop;
            controller._OnPause -= OnPause;
            controller._OnArcThrow -= OnArcThrow;
            controller._OnDirectThrow -= OnDirectThrow;
            controller._OnHoldArcThrow -= OnHoldArcThrow;
            controller._OnHoldDirectThrow -= OnHoldDirectThrow;
        }
    }
    #endregion

    private void Move()
    {
        if (hips.tag != "Grabbed"){
            Vector3 force = new Vector3(movement.x, 0, movement.y) * playerSpeed * Time.deltaTime;
            hipsRigidBody.AddForce(force, ForceMode.Impulse);
            if (Mathf.Abs(movement.x) >= 0.1 || Mathf.Abs(movement.y) >= 0.1)
            {
                hips.transform.forward = new Vector3(movement.x, 0, movement.y);
            }
            animator.Play(force.magnitude >= 0.03 ? "Walk" : "Idle");
        }
    }

    #region Player Abilities
    private void OnMove(InputValue inputValue)
    {
        Vector2 stickDirection = inputValue.Get<Vector2>();
        movement = stickDirection;
    }

    private void OnJump(InputValue inputValue)
    {
        if (canJump && staggerCharges >= 0 && hips.tag != "Grabbed")
        {
            aIsPressed = true;
            canJump = false;
            Vector3 boostDir = hips.transform.up;
            hipsRigidBody.AddForce(boostDir * jumpForce);
            staggerCharges = staggerCharges - staggerJumpCharge;
            OnPlayerExertion(playerNumber, staggerCharges);
            if (!hasStartedRecharging)
            {
                StartCoroutine(rechargeStamina());
            }
        }
    }

    private void OnJumpRelease(InputValue inputValue)
    {
        // This gets the time difference and applies the jump force as a result
        aIsPressed = false;
        canJump = false;
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


    /// <summary>
    /// When a player presses (X)
    /// Either tries garbbing a grabbable object, or dropping it if it is holding one
    /// The grabbable object must have a `base` component and be of type `player` so that we can freeze it from moving
    /// </summary>
    /// <param name="inputValue">Passed by the event, mandatory for strange reasons</param>
    private void OnGrabDrop(InputValue inputValue)
    {
        // GRAB THE PLAYER
        if (grabbing == null) {

            // If there exists a grabbable object in our grabbing range
            if (collisionTrigger.tag == "Grabbable"){
                grabbing = grabCheckCollider.FindClosest(color);
            }

            // If we successfully grabbed a grabbable object
            if (grabbing != null)
            {
                // Get the 'base' of that object
                BaseObject pl = grabbing.GetComponent<BaseObject>();

                // If the object is a player
                if (pl != null) { 
                    pl.player.getHips().GetComponent<Rigidbody>().isKinematic = true;
                }

                // Notify the object its state is "grabbed"
                grabbing.tag = "Grabbed";
                collisionTrigger.tag = "Grabbing";

                // DEBUG - DeleteMe
                //grabbing.GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().GetComponentInParent<Player>().;
                //lineVisual.enabled = true;

                // Freeze the Victim from doing anything
                Player victim = grabbing.GetComponent<BaseObject>().player;
                victim.UnMapControls();
            }
        }
        // DROP THE PLAYER
        else
        {
            // Reset the player's state
            grabbing.tag = "Grabbable";
            collisionTrigger.tag = "Grabbable";

            // Prevent the player from doing anything until they hit the ground
            Player victim = grabbing.GetComponent<BaseObject>().player;     // Get the Vitcim
            victim.isDropped = true;                                        // Make them fall
            victim.canJump = false;                                         // Don't let them get back up

            // Release the grabbed object from our reign
            grabbing.GetComponent<BaseObject>().player.getHips().GetComponent<Rigidbody>().isKinematic = false;
            grabbing = null;

            // DEBUG - DeleteMe
            //Game.Instance.Controllers.GetController(grabbing.GetComponent<BaseObject>().player.playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
            //lineVisual.enabled = false;
        }
    }

    private void OnPause(InputValue inputValue)
    {
        Game.Instance.PauseMenu.Pause(playerNumber);
    }


    /// <summary>
    /// Gets called ON RELEASE of the arcthrow button
    /// </summary>
    /// <param name="inputValue"></param>
    private void OnArcThrow(InputValue inputValue)
    {
        if (grabbing == null) { return; }

        // Debug -- Who is called first? DirectThrow, or HoldDirectThrow
        Debug.Log("THROW (Arc) !!!!!!!!!!!!!!!");

        BaseObject held = grabbing.GetComponent<BaseObject>();
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        VictimVariables();
        OnGrabDrop(null);
        if (held != null)
        {
            held.player.getHips().GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }
        else
        {
            grabbing.GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }

        lineVisual.enabled = false;
        StopCoroutine(renderThrowingLine(arcThrowForceVel, "arc"));
    }


    /// <summary>
    /// Gets called ON RELEASE of the directthrow button
    /// </summary>
    /// <param name="inputValue"></param>
    private void OnDirectThrow(InputValue inputValue)
    {
        // If we are not holding anything
        if (grabbing == null) { return; }

        // Debug -- Who is called first? DirectThrow, or HoldDirectThrow
        Debug.Log("THROW (Direct) !!!!!!!!!!!!!!!");

        // Get reference to what we are holding before we release it
        BaseObject held = grabbing.GetComponent<BaseObject>();
        directThrowForceVel = directThrowForce * directThrowDirection.forward;

        // Set the object to be a projectile
        VictimVariables();
        OnGrabDrop(null);

        // Set the Throw Velocities
        if (held != null)
        {
            held.player.getHips().GetComponent<Rigidbody>().AddForce(directThrowForceVel);
        }
        else
        {
            grabbing.GetComponent<Rigidbody>().AddForce(directThrowForceVel);
        }

        // Render the throwing arc
        lineVisual.enabled = false;
        StopCoroutine(renderThrowingLine(directThrowForceVel, "direct"));
    }

    #endregion

    private void StaggerSelf(bool shouldStagger, TeamColor enemyColor)
    {
        if (Game.Instance == null) return;
        if (shouldStagger == true && enemyColor != color)
        {
            //Debug.Log("Staggered guy");
            Game.Instance.Controllers.GetController(playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
            staggered = true;
            animator.enabled = false;
            staggerStars.SetActive(true);
            if (grabbing) { OnGrabDrop(null); }
            StartCoroutine("UnStagger");
        }
    }

    private IEnumerator UnStagger()
    {
        yield return new WaitForSeconds(staggerTime);
        if (hips.tag != "Grabbed")
        {
            Game.Instance.Controllers.GetController(playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
        staggered = false;
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
 
    public void ResetVelocity()
    {
        hipsRigidBody.velocity = Vector3.zero;
    }

    public GameObject getHips(){
        return hips; 
    }

    private IEnumerator renderThrowingLine(Vector3 throwForce, string throwType){
        while(grabbing)
        {
            //Debug.Log("The time is: " + Time.time);
            if (throwType == "direct") {throwForce = directThrowForce * directThrowDirection.forward;}
            if (throwType == "arc") {throwForce = arcThrowForce * arcThrowDirection.forward;}
            LaunchProjectile(throwForce); 
            yield return new WaitForSeconds (1/60f);
        }
        StopCoroutine(renderThrowingLine(throwForce, throwType));
        lineVisual.enabled = false;
    }

    /// <summary>
    /// This causes the aiming arc to render for the DirectThrow
    /// </summary>
    /// <param name="inputValue"></param>
    void OnHoldDirectThrow(InputValue inputValue){
        // Debug -- Who is called first? DirectThrow, or HoldDirectThrow
        Debug.Log("HOLD (Direct) !!!!!!!!!!!!!!!");

        //Makes line renderer stuff
        directThrowForceVel = directThrowForce * directThrowDirection.forward;
        lineVisual.enabled = true; 
        if(grabbing) {StartCoroutine(renderThrowingLine(directThrowForceVel, "direct"));}
        else { lineVisual.enabled = false;}
    }

    /// <summary>
    /// This causes the aiming arc to render for the ArcThrow
    /// </summary>
    /// <param name="inputValue"></param>
    void OnHoldArcThrow(InputValue inputValue){

        // Debug -- Who is called first? DirectThrow, or HoldDirectThrow
        Debug.Log("HOLD (Arc) !!!!!!!!!!!!!!!");

        //Makes line renderer stuff 
        lineVisual.enabled = true;
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        if(grabbing) {StartCoroutine(renderThrowingLine(arcThrowForceVel, "arc"));}
        else { lineVisual.enabled = false;}
    }

    void LaunchProjectile(Vector3 throwVelocity)
    {
            Vector3 vo = CalculateVelocity(CalculateEndpoint(throwVelocity), grabPos.position, 1f);
            Visualize(vo);
    }

    Vector3 CalculateEndpoint(Vector3 initVelo){
        //Experimental time = 1.54 s
        /* d = v*t + 1/2 a * t^2*/

        //Vector3 spotWhereItHits = new Vector3(initVelo.x*.001f , 0f, initVelo.z*.001f); 
        Vector3 spotWhereItHits = new Vector3(initVelo.x*.001f , initVelo.y*.001f, initVelo.z*.0001f); 
        return spotWhereItHits;
    }

    void Visualize(Vector3 vo)
    {
        /*Make raycast
        See when raycast hits collider
        Put cursor/marker there
        calculate line
        */ 
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i / (float)lineSegment);
            if (i >= lineVisual.positionCount){
                lineVisual.positionCount = i+1; 
            }
            
            lineVisual.SetPosition(i, pos);
        }
    }

    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        //define the distance x and y first                 --------x---------Horizontal        |y| vertical

        Vector3 distance = target - origin;
        Vector3 distanceXz = distance; //Distance on the x&Z plane....This is the same vector as the X, only the y component of the Vector is zeroed out.
        distanceXz.y = 0f;

        //create a float to represent our distance
        float sY = distance.y; //vertical distance (peak) of the arc. Y.
        float sXz = distanceXz.magnitude; //

        //Horizontal velocity.......sxz xz plane distance
        float Vxz = sXz * time;
        //vertical velocity......
        float Vy = (sY / time) + (0.5f * Mathf.Abs(Physics.gravity.y) * time);

        //get the normalized distance of the xz plane. Direction is returned. length will be 1 (normalized).
        Vector3 result = distanceXz.normalized;
        result *= Vxz; //multiply that direction by the horizontal plane velocity
        result.y = Vy; //Set its Y value to velocity of Y

        return result;
    }

    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = grabPos.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + grabPos.position.y;

        result.y = sY;

        return result;
    }
    
}

