using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Stamina stamina { get; private set;}

    [SerializeField] private float playerSpeed = 200f;
    [SerializeField] private float dashForce; // Set in editor
    [SerializeField] private float jumpForce = 12000; // Set in editor
    [SerializeField] private float directThrowForce; // Set in editor
    [SerializeField] private float arcThrowForce; // Set in editor
    [SerializeField] private int staggerTime; // Set in editor

    private Vector3 directThrowForceVel;
    private Vector3 arcThrowForceVel;

    // Airborne Variables
    // Set isThrown to TRUE on any player when they are thrown -> access the grabbed objects isThrown variable
    // Set canJump to FALSE on any player when they are thrown
    public bool isThrown = false;
    public bool canJump;                    // Can the Player jump - the robust value we use for decision making
    // [SerializeField] bool isLanded = false; // Is the plaer on the ground - the raw value to transform into canJump
    public bool dashing;   // Protect this with a Getter
    public bool staggered = false;
    [SerializeField] private float dashVelocityMinimum;
    [SerializeField] private StaggerCheck staggerCheck;

    private Collider hipsCollider;

    private SpriteRenderer sp_cursor;

    [SerializeField] private CheckGrab grabCheckCollider;   // Set in editor
    [SerializeField] private Transform grabPos; // Set in editor
    [SerializeField] private Transform directThrowDirection;
    [SerializeField] private Transform arcThrowDirection;

    [SerializeField] private GameObject grabbing;

    [SerializeField] private GameObject staggerStars;
    [SerializeField] private GameObject collisionTrigger;
    private TrailRenderer trailRenderer;

    private GameObject hips;
    private Animator animator;
    private Rigidbody hipsRigidBody;

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

        AssignMaterial();
        stamina = GetComponent<Stamina>();
        staggerCheck.OnStaggerSelf += StaggerSelf;
    }
    
    void Start()
    {
        canJump = false;

        if (Game.Instance == null) return; // if the preload scene hasn't been loaded
        MapControls();

        hips = transform.GetChild(1).GetChild(0).gameObject; //set reference to player's hips
        hipsRigidBody = hips.GetComponent<Rigidbody>(); //Get Rigidbody for testing stun
        animator = transform.parent.GetChild(1).gameObject.GetComponent<Animator>(); //set reference to player's animator
        hipsCollider = hips.GetComponent<Collider>();

        trailRenderer = transform.GetChild(1).GetChild(0).GetComponent<TrailRenderer>();

        dashing = false;
        grabbing = null;
    }

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
        if (canJump && stamina.CanAfford() && hips.tag != "Grabbed")
        {
            aIsPressed = true;
            canJump = false;
            Vector3 boostDir = hips.transform.up;
            hipsRigidBody.AddForce(boostDir * jumpForce);
            stamina.AddCooldown(playerNumber);
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
            }
        }
        else
        {
            grabbing.tag = "Grabbable";
            collisionTrigger.tag = "Grabbable";

            grabbing.GetComponent<BaseObject>().player.getHips().GetComponent<Rigidbody>().isKinematic = false;
            //Game.Instance.Controllers.GetController(grabbing.GetComponent<BaseObject>().player.playerNumber).GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
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
 
    public void ResetVelocity()
    {
        hipsRigidBody.velocity = Vector3.zero;
    }

    public GameObject getHips(){
        return hips; 
    }
}

