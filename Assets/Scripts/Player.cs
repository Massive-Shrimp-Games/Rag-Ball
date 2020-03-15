

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


/// <summary>
/// Makes this object a RagBall Player.
/// Allows: Staggering, Moving, Dashing.
/// </summary>
public class Player : MonoBehaviour
{
    public Stamina stamina { get; private set;}
    
    #region Variables

    // Team and Player
    public int playerNumber = 0;                                        // The number of the player's controller (from input)
    public TeamColor color;                                             // Which Goal to Score; Which Color to Display
    private Controller controller;          
    
    //Arrow
    [SerializeField] private Sprite BlueArrow;
    [SerializeField] private Sprite RedArrow;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject ArrowArc;
                                                                       // Get Input from ActionMap and Transfer it to the player


    // Movement
    public float playerSpeed;                                           // How fast the player walks
    private Vector2 movement;                                           // Which direction the player is walking

    // Special Abilities
    [SerializeField] private float dashForce = OptionsMenu.dashSpeed;   // How Hard to Dash; Set in editor
    [SerializeField] private float jumpForce = OptionsMenu.jumpHeight;  // How Hard to Jump; Set in editor


    // Direct Throw
    [SerializeField] private float directThrowForce;                    // How hard we Direct Throw
    private Vector3 directThrowForceVel;                                // Sum of DirectThrowForce and Direction
    [SerializeField] private Transform directThrowDirection;            // Where we Direct Throw things

    // Arc Throw
    [SerializeField] private float arcThrowForce;                       // How hard we Arc Throw
    private Vector3 arcThrowForceVel;                                   // Sum of ArcThrowForce and Direction
    [SerializeField] private Transform arcThrowDirection;               // Where we Arc Throw things


    // Stagger Costs
    [SerializeField] private int staggerTime = OptionsMenu.staggerDuration;   // How long to stagger for
    public int staggerCharges;                                          // 
    public int staggerMaxCharge;                                        // 
    public int staggerDashCharge;                                       // 
    public int staggerJumpCharge;                                       // ???


    // Airborne Variables
    // Set isThrown to TRUE on any player when they are thrown -> access the grabbed objects isThrown variable
    // Set canJump to FALSE on any player when they are thrown
    public bool isThrown = false;
    public bool canJump = false;                                        // Can the Player jump - the robust value we use for decision making
    public bool isDropped = false;                                      // Stupid Extra Variable grrrrrrrrr


    // Stagger Variables
    public bool dashing;                                                // TODO Protect this with a Getter
    public bool staggered = false;                                      // Can the player move, be picked up, etc.
    [SerializeField] private float dashVelocityMinimum;                 // Velocity of an incoming object to trigger staggered state
    [SerializeField] private StaggerCheck staggerCheck;                 // ???


    // Body Parts
    private Collider hipsCollider;
    private GameObject hips;
    private Animator animator;
    private Rigidbody hipsRigidBody;


    // Charging
    private bool isRecharging;                                      // Is the player currently gaining stamina?
    private bool hasStartedRecharging;                              // Did the player start gaining stamina?

    //score for ROTH (gross but effective)
    private int ROTHScore = 0;
    [SerializeField] GameObject ROTHScoreObject;

    // Menus
    private SpriteRenderer sp_cursor;                               // What we draw on screen


    // Grabbing
    [SerializeField] private CheckGrab grabCheckCollider;           // Set in editor
    [SerializeField] private Transform grabPos;                     // Set in editor
    [SerializeField] private GameObject collisionTrigger;           // How we check for grabbable objects
    [SerializeField] private GameObject grabbing;                   // What we are grabbing


    // Special Effects
    [SerializeField] private GameObject staggerStars;               // TODO Instead of this, have a particle handler
    private TrailRenderer trailRenderer;                            // Renders a trail after the player
    public RagdollSize size;                                        // For GameOver screen, tells us which type of character to spawn


    // Throwing Arc
    //Used for creating the visualized arc when throwing
    public int lineSegment = 3;                                     // How many segments to split the line into
    private LineRenderer lineVisual;                                // What draws the line
    public LayerMask layer;                                         // Which layer the line is displayed on

    //Jump Variables
    [SerializeField] private float fallMultiplier;                  // When the player has reached the top of their arc, fall faster
    [SerializeField] private float jumpMultiplier;                  // Before the player has reached the top of their arc, fall slower
    private bool aIsPressed = false;                                // Is the player holding the jump button?

 



    #endregion





    #region Lifecycles



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
        //lineVisual = hips.transform.parent.parent.GetChild(2).GetChild(1).gameObject.GetComponent<LineRenderer>();
        AssignMaterial();
        stamina = GetComponent<Stamina>();

        // Statuses
        staggerCheck.OnStaggerSelf += StaggerSelf;
        OptionsMenu.OptionsChangeEvent += OptionsChange;
    }


    /// <summary>
    /// Set Initial Values and References for the player's Systems on Spawn
    /// </summary>
    void Start()
    {
        if (Game.Instance == null) return; // if the preload scene hasn't been loaded
        MapControls();

        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.GetComponent<Collider>();

        trailRenderer = transform.GetChild(1).GetChild(0).GetComponent<TrailRenderer>();

        canJump = false;
        dashing = false;
        grabbing = null;

        if(color == TeamColor.Red)
        {
            Arrow.GetComponent<SpriteRenderer>().sprite = RedArrow;
            ArrowArc.GetComponent<SpriteRenderer>().sprite = RedArrow;
        } else if (color == TeamColor.Blue)
        {
            Arrow.GetComponent<SpriteRenderer>().sprite = BlueArrow;
            ArrowArc.GetComponent<SpriteRenderer>().sprite = BlueArrow;
        }
        ROTHScoreObject.GetComponent<TextMeshPro>().text = "0";
        ROTHScoreObject.SetActive(true);
        if(color == TeamColor.Red)
        {
            ROTHScoreObject.GetComponent<TextMeshPro>().color = Color.red;
        } else
        {
            ROTHScoreObject.GetComponent<TextMeshPro>().color = Color.cyan;
        }
        ROTHScoreObject.GetComponent<TextMeshPro>().text = "P" + (playerNumber + 1);
    }

    /// <summary>
    /// Checks if Jumping, Dashing, Jumping, beingThrown, and oter Active Statuses are in Effect
    /// </summary>
    private void Update()
    {
        UpdateHeld();
        bool leftFoot = hips.transform.Find("thigh.L/shin.L/foot.L").GetComponent<MagicSlipper>().touching;
        bool rightFoot = hips.transform.Find("thigh.R/shin.R/foot.R").GetComponent<MagicSlipper>().touching;
        canJump = leftFoot || rightFoot;

        staggerStars.transform.Rotate(staggerStars.transform.up, 1f);
        Move();
        JumpPhysics();
        UpdateThrown();

        float determinDirection = Vector3.Dot(hipsRigidBody.velocity.normalized, hips.transform.forward);
        float determineMagnitue = hipsRigidBody.velocity.magnitude;
        dashing = (hipsRigidBody.velocity.magnitude > dashVelocityMinimum) && (Mathf.Abs(determinDirection) > .5);

        if (dashing)
        {
            trailRenderer.enabled = true;
        }
        else
        {
            trailRenderer.enabled = false;
        }
        if(ROTHScoreObject.active)
        {
            ROTHScoreObject.transform.eulerAngles = Vector3.zero;
        }
    }
    public void updateScore(int score)
    {
        ROTHScore = score;
        ROTHScoreObject.GetComponent<TextMeshPro>().text = "P" + (playerNumber + 1) + ": " + ROTHScore.ToString();
    }
    private void OnDestroy()
    {
        UnMapControls();            // Reset the controls on this object so another can listen to them
        OptionsMenu.OptionsChangeEvent -= OptionsChange;
    }



    #endregion





    #region Helpers



    /// <summary>
    /// Assigns the team's Material to the Player's Renderer
    /// based on their Size and Color
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
        // When player is airborne after pressing jump button (not after being thrown, not after being picked up)
        if (!canJump && !isThrown)
        {
            // They are holding the jump button, and they have not reached the top of their arc
            if (hips.GetComponent<Rigidbody>().velocity.y > 0 && aIsPressed)
            {
                // Fall softly
                hipsRigidBody.velocity += Vector3.up * Physics.gravity.y * (jumpMultiplier - 1) * Time.deltaTime;
            }
            // They are not holding jump, or have reached the top of their arc
            else
            {
                // Fall sharply
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
        // If player was thrown
        // Does NOT call ReMap Controls -- defaults to DROPPING calling Remap
        if (canJump && isThrown)
        {
            isThrown = false;
        }
        // If player was dropped
        // DOES call ReMapControls
        else if (canJump && isDropped)
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
            if (victim == null) return;             // This is for throwing non-players
            victim.isThrown = true;
            victim.canJump = false;                 // Don't want them getting away now, do we? H AH AH A HA HA AH HA A HA !!!!!
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

    private void Move()
    {
        if (hips.tag != "Grabbed")
        {
            Vector3 force = new Vector3(movement.x, 0, movement.y) * playerSpeed * Time.deltaTime;
            hipsRigidBody.AddForce(force, ForceMode.Impulse);
            if (Mathf.Abs(movement.x) >= 0.1 || Mathf.Abs(movement.y) >= 0.1)
            {
                hips.transform.forward = new Vector3(movement.x, 0, movement.y);
            }
            animator.Play(force.magnitude >= 0.03 ? "Walk" : "Idle");
        }
    }


    /// <summary>
    /// WHO USES THIS AND WHY ?!?!?!?!?!
    /// </summary>
    public void ResetVelocity()
    {
        hipsRigidBody.velocity = Vector3.zero;
    }


    /// <summary>
    /// Get the Player's Hips
    /// </summary>
    /// <returns></returns>
    public GameObject getHips()
    {
        return hips;
    }

    /// <summary>
    /// Updates parameters set from options menu
    /// </summary>
    /// <returns></returns>
    private void OptionsChange()
    {
        dashForce = OptionsMenu.dashSpeed;
        jumpForce = OptionsMenu.jumpHeight;
        staggerTime = OptionsMenu.staggerDuration;
    }

    #endregion





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





    #region Player Abilities



    private void OnMove(InputValue inputValue)
    {
        Vector2 stickDirection = inputValue.Get<Vector2>();
        movement = stickDirection;
    }

    private void OnJump(InputValue inputValue)
    {
        if (canJump && stamina.CanAfford() && hips.tag != "Grabbed")
        {
            aIsPressed = true;
            canJump = false;
            Vector3 boostDir = hips.transform.up;
            hipsRigidBody.AddForce(boostDir * jumpForce);
            stamina.AddCooldown(playerNumber);
            Game.Instance.SFX.PlayAudio("jump");

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
        if (stamina.CanAfford() && hips.tag != "Grabbed")
        {
            Vector3 boostDir = hips.transform.forward;
            hipsRigidBody.AddForce(boostDir * dashForce);
            stamina.AddCooldown(playerNumber);
            Game.Instance.SFX.PlayAudio("dash");

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


    /// <summary>
    /// Opens the pause menu
    /// </summary>
    /// <param name="inputValue"></param>
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
        // If we are not holding anything
        if (grabbing == null) { return; }

        // Get reference to what we are holding before we release it
        BaseObject held = grabbing.GetComponent<BaseObject>();
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;

        // Set the object to be a projectile
        VictimVariables();
        OnGrabDrop(null);

        // Set the Throw Velocities
        if (held != null)
        {
            held.player.getHips().GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }
        else
        {
            grabbing.GetComponent<Rigidbody>().AddForce(arcThrowForceVel);
        }

        // Render the throwing arc
        Game.Instance.SFX.PlayAudio("throw");

        //lineVisual.enabled = false;
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
        Game.Instance.SFX.PlayAudio("throw");
        //lineVisual.enabled = false;
        StopCoroutine(renderThrowingLine(directThrowForceVel, "direct"));
    }

    /// <summary>
    /// This causes the aiming arc to render for the DirectThrow
    /// </summary>
    /// <param name="inputValue"></param>
    void OnHoldDirectThrow(InputValue inputValue)
    {
        //Makes line renderer stuff
        directThrowForceVel = directThrowForce * directThrowDirection.forward;
        //lineVisual.enabled = true;
        if (grabbing) { StartCoroutine(renderThrowingLine(directThrowForceVel, "direct")); }
        //else { lineVisual.enabled = false; }
    }

    /// <summary>
    /// This causes the aiming arc to render for the ArcThrow
    /// </summary>
    /// <param name="inputValue"></param>
    void OnHoldArcThrow(InputValue inputValue)
    {
        //Makes line renderer stuff 
        //lineVisual.enabled = true;
        arcThrowForceVel = arcThrowForce * arcThrowDirection.forward;
        if (grabbing) { StartCoroutine(renderThrowingLine(arcThrowForceVel, "arc")); }
        //else { lineVisual.enabled = false; }
    }



    #endregion





    #region Stagger



    /// <summary>
    /// Staggers THIS Object
    /// </summary>
    /// <param name="shouldStagger"></param>
    /// <param name="enemyColor"></param>
    private void StaggerSelf(bool shouldStagger, TeamColor enemyColor)
    {
        if (Game.Instance == null) return;
        if (shouldStagger == true && enemyColor != color)
        {
            Game.Instance.Controllers.GetController(playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
            staggered = true;
            animator.enabled = false;
            staggerStars.SetActive(true);
             Game.Instance.SFX.PlayAudio("stagger");
            if (grabbing) { OnGrabDrop(null); }
            StartCoroutine("UnStagger");
        }
    }

    /// <summary>
    /// Unstaggers THIS Object
    /// </summary>
    /// <returns></returns>
    private IEnumerator UnStagger()
    {
        yield return new WaitForSeconds(staggerTime);
        if (hips.tag != "Grabbed")
        {
            Game.Instance.Controllers.GetController(playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
        staggered = false;
        Game.Instance.SFX.StopSound("stagger");
        animator.enabled = true;
        staggerStars.SetActive(false);
    }



    #endregion





    #region ThrowLine



    private IEnumerator renderThrowingLine(Vector3 throwForce, string throwType){
        while(grabbing)
        {
            Vector3 angle = Arrow.transform.forward;
            if (throwType == "direct") {
                Debug.Log("DirectThrow");
                Arrow.SetActive(true);
                ArrowArc.SetActive(false);
            }
            if (throwType == "arc") {
                ArrowArc.SetActive(true);
                Arrow.SetActive(false);
            }
            //LaunchProjectile(throwForce); 
            yield return new WaitForSeconds (1/60f);
        }
        Arrow.SetActive(false);
        ArrowArc.SetActive(false);
        StopCoroutine(renderThrowingLine(throwForce, throwType));
        //lineVisual.enabled = false;
    }


    void LaunchProjectile(Vector3 throwVelocity)
    {
            Vector3 vo = CalculateVelocity(CalculateEndpoint(throwVelocity), grabPos.position, 1f);
    }

    Vector3 CalculateEndpoint(Vector3 initVelo){
        //Experimental time = 1.54 s
        /* d = v*t + 1/2 a * t^2*/

        //Vector3 spotWhereItHits = new Vector3(initVelo.x*.001f , 0f, initVelo.z*.001f); 
        Vector3 spotWhereItHits = new Vector3(initVelo.x*.001f , initVelo.y*.001f, initVelo.z*.0001f); 
        return spotWhereItHits;
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



    #endregion





}

