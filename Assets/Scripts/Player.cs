using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Player : MonoBehaviour
{

    public delegate void Exert(int player, int stamina);

    public event Exert OnPlayerExertion;

    [SerializeField] private float dashForce; // Set in editor
    [SerializeField] private float jumpForce = 12000; // Set in editor
    [SerializeField] private float directThrowForce; // Set in editor
    [SerializeField] private float arcThrowForce; // Set in editor
    [SerializeField] private int staggerTime; // Set in editor

    private Vector3 directThrowForceVel;
    private Vector3 arcThrowForceVel;

    public float playerSpeed = 200f;
    public int staggerCharges;
    public int staggerMaxCharge;
    public int staggerDashCharge;
    public int staggerJumpCharge;
    //private int staminaCharges;


    // Airborne Variables
    // Set isThrown to TRUE on any player when they are thrown -> access the grabbed objects isThrown variable
    // Set canJump to FALSE on any player when they are thrown
    public bool isThrown = false;
    public bool canJump;                    // Can the Player jump - the robust value we use for decision making
    [SerializeField] bool isLanded = false; // Is the plaer on the ground - the raw value to transform into canJump
    public bool dashing;   // Protect this with a Getter
    public bool staggered = false;
    [SerializeField] private float dashVelocityMinimum;
    [SerializeField] private StaggerCheck staggerCheck;


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
    [SerializeField] private float fallMultiplier = 60f;
    [SerializeField] private float jumpMultiplier = 12f;
    private bool aIsPressed = false;

    private Vector2 movement;

    public int playerNumber = 0;
    public RagdollSize size;
    public TeamColor color;
    private Controller controller;

    void Awake()
    {
        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.gameObject.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.gameObject.GetComponent<Collider>();
        trailRenderer = hips.GetComponent<TrailRenderer>();
        lineVisual = hips.transform.parent.parent.GetChild(2).GetChild(1).gameObject.GetComponent<LineRenderer>(); 

        AssignMaterial();
        staggerCheck.OnStaggerSelf += StaggerSelf;
    }

    private void AssignMaterial()
    {
        if (color == TeamColor.Red)
        {
            if(size == RagdollSize.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Small");
                
            } else if (size == RagdollSize.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Medium");
            } else if (size == RagdollSize.Large)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Red_Large");
            }
            transform.Find("Pivot/Character_DirectionalCircle_Red_01_0").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Character_DirectionalCircle_Red_01");
        }
        else if (color == TeamColor.Blue)
        {
            if(size == RagdollSize.Small)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Small");
            } else if (size == RagdollSize.Medium)
            {
                transform.GetChild(0).gameObject.GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Player/Blue_Medium");
            } else if (size == RagdollSize.Large)
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
        if (! canJump)
        {
            canJump = isLanded;
        }
        isLanded = leftFoot || rightFoot;

        staggerStars.transform.Rotate(staggerStars.transform.up, 1f);
        Move();
        JumpPhysics();
        UpdateThrown();

        if (isRecharging == false && hasStartedRecharging == true){
            StartCoroutine(rechargeStamina());
        }

        float determinDirection = Vector3.Dot(hipsRigidBody.velocity.normalized, hips.transform.forward);
        float determineMagnitue = hipsRigidBody.velocity.magnitude;
        dashing = (hipsRigidBody.velocity.magnitude > dashVelocityMinimum) && (Mathf.Abs(determinDirection) > .5) ;
        print("DotPrd:\t" + determinDirection + "Mag:\t" + determineMagnitue + "Should dash:\t" + dashing);

        if (dashing)
        {
            trailRenderer.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
        }
    }

    /// <summary>
    /// Controls decay of player as they fall, called from UPDATE
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
    /// </summary>
    private void UpdateThrown()
    {
        if (isThrown && canJump)
        {
            isThrown = false;
        }
    }

    /// <summary>
    /// Set a victim's canJump and isThrown from a 'OnThrow' event
    /// ATTN: Assumes 'grabbing' is NOT NULL
    /// </summary>
    private void VictimVariables()
    {
        if (grabbing)
        {
            Player victim = grabbing.GetComponent<BaseObject>().player;
            if (victim == null) return; // This is for throwing non-players
            victim.isThrown = true;
            victim.canJump = false; // Don't want them getting away now, do we? H AH AH A HA HA AH HA A HA !!!!!
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
            //Vector2 stickDirection = inputValue.Get<Vector2>();
            Vector3 force = new Vector3(movement.x, 0, movement.y) * playerSpeed * Time.deltaTime;
            hipsRigidBody.AddForce(force, ForceMode.Impulse);
            //Debug.LogFormat("stickDir is {0}", movement);
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

    private void OnGrabDrop(InputValue inputValue)
    {
        if (grabbing == null) {
            if (collisionTrigger.tag == "Grabbable"){
                grabbing = grabCheckCollider.FindClosest(color);
            }
            if (grabbing != null)
            {
                BaseObject pl = grabbing.GetComponent<BaseObject>();
                if (pl != null)
                    pl.player.getHips().GetComponent<Rigidbody>().isKinematic = true;
                grabbing.tag = "Grabbed";
                //grabbing.GetComponentInParent<GameObject>().GetComponentInParent<GameObject>().GetComponentInParent<Player>().;
                collisionTrigger.tag = "Grabbing";
                //lineVisual.enabled = true;
            }
        }
        else
        {
            grabbing.tag = "Grabbable";
            collisionTrigger.tag = "Grabbable";

            grabbing.GetComponent<BaseObject>().player.getHips().GetComponent<Rigidbody>().isKinematic = false;
            //Game.Instance.Controllers.GetController(grabbing.GetComponent<BaseObject>().player.playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
            grabbing = null; 
            //lineVisual.enabled = false;
        }
    }

    private void OnPause(InputValue inputValue)
    {
        Game.Instance.PauseMenu.Pause(playerNumber);
    }

    private void OnArcThrow(InputValue inputValue)
    {
        if (grabbing == null) { return; }
        
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        OnGrabDrop(null);
        BaseObject held = grabbing.GetComponent<BaseObject>();
        if (held != null)
        {
            held.player.getHips().GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }
        else
        {
            grabbing.GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }

        VictimVariables();
        lineVisual.enabled = false;
        StopCoroutine(renderThrowingLine(arcThrowForceVel, "arc"));
    }

    private void OnDirectThrow(InputValue inputValue)
    {
        if (grabbing == null) { return; }
        
        // Get reference to what we are holding before we release it
        BaseObject held = grabbing.GetComponent<BaseObject>();
        directThrowForceVel = directThrowForce * directThrowDirection.forward;

        VictimVariables();
        OnGrabDrop(null);
        if (held != null)
        {
            held.player.getHips().GetComponent<Rigidbody>().AddForce(directThrowForceVel);
        }
        else
        {
            grabbing.GetComponent<Rigidbody>().AddForce(directThrowForceVel);
        }
        lineVisual.enabled = false;
        StopCoroutine(renderThrowingLine(directThrowForceVel, "direct"));
    }

    #endregion

    private void StaggerSelf(bool shouldStagger, TeamColor enemyColor)
    {
        if (Game.Instance == null) return;
        if (shouldStagger == true && enemyColor != color)
        {
            Debug.Log("Staggered guy");
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
            Debug.Log("The time is: " + Time.time);
            if (throwType == "direct") {throwForce = directThrowForce * directThrowDirection.forward;}
            if (throwType == "arc") {throwForce = arcThrowForce * arcThrowDirection.forward;}
            LaunchProjectile(throwForce); 
            yield return new WaitForSeconds (0.25f);
        }
        StopCoroutine(renderThrowingLine(throwForce, throwType));
        lineVisual.enabled = false;
    }

    void OnHoldDirectThrow(InputValue inputValue){
        //Makes line renderer stuff
        Debug.Log("I am Hold Direct, here i am"); 
        directThrowForceVel = directThrowForce * directThrowDirection.forward;
        lineVisual.enabled = true; 
        if(grabbing) {StartCoroutine(renderThrowingLine(directThrowForceVel, "direct"));}
        else { lineVisual.enabled = false;}
    }

    void OnHoldArcThrow(InputValue inputValue){
        //Makes line renderer stuff 
        lineVisual.enabled = true;
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        if(grabbing) {StartCoroutine(renderThrowingLine(arcThrowForceVel, "arc"));}
        else { lineVisual.enabled = false;}
    }

    void LaunchProjectile(Vector3 throwVelocity)
    {
    	/*
        Direction of player
        hips.transform.forward
        */
        
        /* <-- where the object thrown is held --> where the object thrown is landing
        
        	force of the throw, the weight of what's being thrown and the direction
          		where it's landing
              
        	force of throw -> directThrowForceVel OR arcThrowForceVel
          weight of object -> Found in inspector (probably)
          //direction -> hips.transform.forward OR ArcThrowDirection/DirectThrowDirection
        
        */
        //Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        //Ray playerThrowRay = new Ray(hips.transform.position, hips.transform.forward); 
        //RaycastHit hit;//This is the point where out mouse cursor is
        //lineVisual.enabled = true; 
        //playerThrowRay
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 40f))
        //{
        //    Debug.Log("we might get rid of this conditional statement");
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)*hit.distance, Color.yellow);
            //endPoint calculation function called here
            //getting rid of anything that deals with the mouse. 
            //Making sure it works.
            //cursor.SetActive(true);
            //cursor.transform.position = hit.point + Vector3.up * 0.1f;

            //Vector3 vo = CalculateVelocity(hit.point, grabPos.position, 1f);
            Vector3 vo = CalculateVelocity(CalculateEndpoint(throwVelocity), grabPos.position, 1f);

            Visualize(vo);
        //}
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

