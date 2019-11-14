using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure; // Required in C#




/*
 *                      ATTENTION!
 *                      
 *             ABBANDON ALL HOPE YE WHOMST ENTER!
 *             BEWARE, THIS BE THE DREADED...
 *                                                                                                        
                                                                                                                 
        GGGGGGGGGGGGG     OOOOOOOOO     DDDDDDDDDDDDD                                                            
     GGG::::::::::::G   OO:::::::::OO   D::::::::::::DDD                                                         
   GG:::::::::::::::G OO:::::::::::::OO D:::::::::::::::DD                                                       
  G:::::GGGGGGGG::::GO:::::::OOO:::::::ODDD:::::DDDDD:::::D                                                      
 G:::::G       GGGGGGO::::::O   O::::::O  D:::::D    D:::::D                                                     
G:::::G              O:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G              O:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G    GGGGGGGGGGO:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G    G::::::::GO:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G    GGGGG::::GO:::::O     O:::::O  D:::::D     D:::::D                                                    
G:::::G        G::::GO:::::O     O:::::O  D:::::D     D:::::D                                                    
 G:::::G       G::::GO::::::O   O::::::O  D:::::D    D:::::D                                                     
  G:::::GGGGGGGG::::GO:::::::OOO:::::::ODDD:::::DDDDD:::::D                                                      
   GG:::::::::::::::G OO:::::::::::::OO D:::::::::::::::DD                                                       
     GGG::::::GGG:::G   OO:::::::::OO   D::::::::::::DDD                                                         
        GGGGGG   GGGG     OOOOOOOOO     DDDDDDDDDDDDD                                                            
                                                                                                                 
                                                                                                                 
                                                                        
                                                                                                                 
                                                                                                                 
   SSSSSSSSSSSSSSS         CCCCCCCCCCCCCRRRRRRRRRRRRRRRRR   IIIIIIIIIIPPPPPPPPPPPPPPPPP   TTTTTTTTTTTTTTTTTTTTTTT
 SS:::::::::::::::S     CCC::::::::::::CR::::::::::::::::R  I::::::::IP::::::::::::::::P  T:::::::::::::::::::::T
S:::::SSSSSS::::::S   CC:::::::::::::::CR::::::RRRRRR:::::R I::::::::IP::::::PPPPPP:::::P T:::::::::::::::::::::T
S:::::S     SSSSSSS  C:::::CCCCCCCC::::CRR:::::R     R:::::RII::::::IIPP:::::P     P:::::PT:::::TT:::::::TT:::::T
S:::::S             C:::::C       CCCCCC  R::::R     R:::::R  I::::I    P::::P     P:::::PTTTTTT  T:::::T  TTTTTT
S:::::S            C:::::C                R::::R     R:::::R  I::::I    P::::P     P:::::P        T:::::T        
 S::::SSSS         C:::::C                R::::RRRRRR:::::R   I::::I    P::::PPPPPP:::::P         T:::::T        
  SS::::::SSSSS    C:::::C                R:::::::::::::RR    I::::I    P:::::::::::::PP          T:::::T        
    SSS::::::::SS  C:::::C                R::::RRRRRR:::::R   I::::I    P::::PPPPPPPPP            T:::::T        
       SSSSSS::::S C:::::C                R::::R     R:::::R  I::::I    P::::P                    T:::::T        
            S:::::SC:::::C                R::::R     R:::::R  I::::I    P::::P                    T:::::T        
            S:::::S C:::::C       CCCCCC  R::::R     R:::::R  I::::I    P::::P                    T:::::T        
SSSSSSS     S:::::S  C:::::CCCCCCCC::::CRR:::::R     R:::::RII::::::IIPP::::::PP                TT:::::::TT      
S::::::SSSSSS:::::S   CC:::::::::::::::CR::::::R     R:::::RI::::::::IP::::::::P                T:::::::::T      
S:::::::::::::::SS      CCC::::::::::::CR::::::R     R:::::RI::::::::IP::::::::P                T:::::::::T      
 SSSSSSSSSSSSSSS           CCCCCCCCCCCCCRRRRRRRR     RRRRRRRIIIIIIIIIIPPPPPPPPPP                TTTTTTTTTTT      
                                                                                                                 
                                                                                           
 *               
 *             MUA HAHAHAHAHAHAHAHA HHAHAHAHA HAH HAH AHA HAH HAH 
 *                   AAAAAAAHAHAHHHHHH HA HAHAHA HAH AH HA HAHA HA HA
 *                          HHAHAH AH HAH HAH AH 
 *                                  HA HA HA HA H
 *                                      HAHA
 *                              
 *                                           HA 
 *                              
 *                                               ...
 *                              
 *                                                   HA..................
 * 
 */












//namespace LocalCoop {
/// <summary>
/// A manager that can be used to add players without having pre-assigned controlled ID's to the input
/// </summary>
public class PlayerManager : MonoBehaviour {

    PlayerIndex controllerID1;
    PlayerIndex controllerID2;
    PlayerIndex controllerID3;
    PlayerIndex controllerID4;
    GamePadState controller1state;
    GamePadState controller2state;
    GamePadState controller3state;
    GamePadState controller4state;

    public GameObject[] players = new GameObject[4];
    GamePadState[] GamePadStates;
    public Animator[] Animators;
    public Transform[] RotatePlayers;
    public Transform[] Pivots;
    private PlayerIndex[] PlayerIndexes;
    public GameObject[,] PlayerHands;
    public GameObject[] PlayerHips;

    //button arrays
    private bool[] BwasPressed;
    private bool[] YwasPressed;
    private bool[] XwasPressed;
    private bool[] StartwasPressed;

    //respawn objects
    public GameObject RedPlayer;
    public GameObject BluePlayer;
    public GameObject RespawnPoint;
    public GameObject AnimatorRespawnPoint;
    public ScoreManager scoremanager;
    public bool GameIsPaused;

    //PER PLAYER
    //public Animator animator1;
    //public Transform rotatePlayer1;
    //public Transform pivot1;
    //public Animator animator2;
    //public Transform rotatePlayer2;
    //public Transform pivot2;
    //public Animator animator3;
    //public Transform rotatePlayer3;
    //public Transform pivot3;

    public bool use_X_Input = true;
    public int connectedControllers = 0;   //if this variable changes, we need to call an update on the gamepads

    public static PlayerManager singleton = null;

    public Canvas PauseMenu;

    void Awake() {
        //Check if instance already exists
        if (singleton == null) {
            //if not, set instance to this
            singleton = this;
        }

        //If instance already exists and it's not this:
        else if (singleton != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        connectedControllers = CheckControllerAmount();
        Assign_X_Input_Controllers();

        GamePadStates = new GamePadState[] {
            controller1state,
            controller2state,
            controller3state,
            controller4state,
        };

        PlayerIndexes = new PlayerIndex[] {
            controllerID1,
            controllerID2,
            controllerID3,
            controllerID4,
        };

        //Player 1: [0 0] [0 1]
        //Player 2: [1 0] [1 1]
        //Player 3: [2 0] [2 1]
        //Player 4: [3 0] [3 1]
        PlayerHands = new GameObject[,] {
            { players[0].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[0].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[1].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[1].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[2].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[2].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
            { players[3].transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject,
                players[3].transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject},
        };

        PlayerHips = new GameObject[] {
            players[0].transform.Find("Player/metarig/hips").gameObject,
            players[1].transform.Find("Player/metarig/hips").gameObject,
            players[2].transform.Find("Player/metarig/hips").gameObject,
            players[3].transform.Find("Player/metarig/hips").gameObject,
        };

        BwasPressed = new bool[] {
            false,
            false,
            false,
            false,
        };

        YwasPressed = new bool[] {
            false,
            false,
            false,
            false,
        };

        XwasPressed = new bool[] {
            false,
            false,
            false,
            false,
        };

        StartwasPressed = new bool[] {
            false,
            false,
            false,
            false,
        };
    }

    void Assign_X_Input_Controllers() {
        for (int i = 0; i < 4; ++i) {
            PlayerIndex controllerID = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(controllerID);
            if (testState.IsConnected) {
                switch (i) {
                    case 0:
                        controllerID1 = controllerID;
                        controller1state = testState;
                        break;
                    case 1:
                        controllerID2 = controllerID;
                        controller2state = testState;
                        break;
                    case 2:
                        controllerID3 = controllerID;
                        controller3state = testState;
                        break;
                    case 3:
                        controllerID4 = controllerID;
                        controller4state = testState;
                        break;
                    default:
                        break;
                }

                Debug.Log(string.Format("GamePad found {0}", controllerID));
            }
        }
    }

    //Checks if the amount of controllers changed when connecting/unplugging new controllers
    int CheckControllerAmount() {
        int amount = 0;

        for (int i = 0; i < 4; ++i) {
            PlayerIndex controllerID = (PlayerIndex)i;
            GamePadState testState = GamePad.GetState(controllerID);
            if (testState.IsConnected) {
                amount++;
            }
        }

        return amount;
    }


    public void respawn(int pNumber)
    {
        GameObject newPlayer;

        //Spawn Blue Player
        if (pNumber % 2 == 1)
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //newPlayer = BluePlayer;
            newPlayer = Instantiate(BluePlayer, RespawnPoint.transform.position, Quaternion.identity);
            newPlayer.GetComponent<PlayerModel>().PlayerColor = "blue";
        }
        //Spawn Red Player
        else
        {
            //Instantiate(myPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            //newPlayer = RedPlayer;
            newPlayer = Instantiate(RedPlayer, RespawnPoint.transform.position, Quaternion.identity);
            newPlayer.GetComponent<PlayerModel>().PlayerColor = "red";
        }
        Destroy(players[pNumber]);
        newPlayer.transform.Find("MediumStaticAnimator").transform.position = AnimatorRespawnPoint.transform.position;
        //newPlayer.transform.position = RespawnPoint.transform.position;
        players[pNumber] = newPlayer;
        Animators[pNumber] = newPlayer.transform.Find("MediumStaticAnimator").GetComponent<Animator>();
        RotatePlayers[pNumber] = newPlayer.transform.Find("Player").transform;
        Pivots[pNumber] = newPlayer.transform.Find("Pivot");
        newPlayer.GetComponent<PlayerModel>().PlayerNumber = pNumber;
        newPlayer.transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(0, -2500, 0);
        newPlayer.GetComponent<PlayerModel>().playermanager = this;
        newPlayer.GetComponent<PlayerModel>().scoremanager = scoremanager;
        PlayerHands[pNumber, 0] = newPlayer.transform.Find("Player/metarig/hips/spine/chest/shoulder.L/upper_arm.L/forearm.L").gameObject;
        PlayerHands[pNumber, 1] = newPlayer.transform.Find("Player/metarig/hips/spine/chest/shoulder.R/upper_arm.R/forearm.R").gameObject;
        PlayerHips[pNumber] = newPlayer.transform.Find("Player/metarig/hips").gameObject;
        newPlayer.name = "Player" + (pNumber+1).ToString();
        newPlayer.transform.Find("Player/metarig/hips/").gameObject.GetComponent<Grabbable>().myPlayer = pNumber;
        GameObject theHips = newPlayer.transform.Find("Player/metarig/hips/").gameObject;
        Debug.Log("Player's Hips are: " + theHips.GetComponent<Grabbable>().myPlayer.ToString());
    }

    public void Grab(int Grabber)
    {
        //ALERT!
        Debug.Log("OH yeah boyyyy");

        // Find Tha Hips
        GameObject theGrabbler = players[Grabber];
        GameObject maHips = theGrabbler.transform.Find("Player/metarig/hips/").gameObject;
        GameObject tharHips = theGrabbler.transform.Find("Player/metarig/hips/").gameObject.GetComponent<Grabbable>().tharHips;

        if (tharHips != null)
        { 
            Debug.Log("And here we go");
        }
        else
        {
            Debug.Log("OHHHHHHHHHHH NOOOOOOOOOOOOOOOOO!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }

        //Check if he can throw
        if (maHips.GetComponent<Grabbable>().iCanGrab == true)
        {
            // Move 'im up
            tharHips.transform.position = maHips.transform.position;
            tharHips.transform.Translate(0f, 1.5f, 0f);

            // Lock 'im in, Yup!
            
        }
    }
//TIME CHANGER
//Updates any timers you want to use
//dashes[i] corresponds to players[i] and is an integer array of remaining dashes (0 - None, 5 - Max)
//staminas[i] corresponds to players[i] and is an float array of remaining balance (0 - None, 100 - Max)
//dashtimes[i] corresponds to players[i] and is a float array of time until a dash is added
//staminatimes[i] corresponds to players[i] and is a float array of time until balance is added
private void UpdateTimers()
{
    for (int i = 0; i < 4; i++)
    {
        // TODO
        //dashtimes[i] - Time.DeltaTime
        //if (dashtimes[i] <= 0)
        //{
        //dashes[i] += 1;
        //}
    }
}

    // Update is called once per frame
    void Update() {
        if (use_X_Input) {
            if (connectedControllers != CheckControllerAmount()) {
                connectedControllers = CheckControllerAmount();
                print("update controllers");
                Assign_X_Input_Controllers();
            }

            if (controller1state.IsConnected) {
                controller1state = GamePad.GetState(controllerID1);
                if (controller1state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 0 pressed start");
                    //you can call a function here to instantiate a player and then assign this ID to the player input's script to connect the player to the controller that pressed start for example
                    //you then also need to assign that player input script to one of the X input modules to connect it with unity's input system
                }
            }

            if (controller2state.IsConnected) {
                controller2state = GamePad.GetState(controllerID2);
                if (controller2state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 1 pressed start");
                }
            }

            if (controller3state.IsConnected) {
                controller3state = GamePad.GetState(controllerID3);
                if (controller3state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 2 pressed start");
                }
            }

            if (controller4state.IsConnected) {
                controller4state = GamePad.GetState(controllerID4);
                if (controller4state.Buttons.Start == ButtonState.Pressed) {
                    print("Controller with ID 3 pressed start");
                }
            }

            //vvv
            for (int i = 0; i < 4; i++)
            {
                float H = GamePadStates[i].ThumbSticks.Left.X + GamePadStates[i].ThumbSticks.Right.X;
                float V = GamePadStates[i].ThumbSticks.Left.Y + GamePadStates[i].ThumbSticks.Right.Y;

                //movement
                Vector3 Movement = new Vector3();
                Movement.Set(H, 0f, V);
                Movement = Movement.normalized * 2 * Time.deltaTime;
                players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(Movement * 1000f);
                //RotatePlayers[i].transform.position = players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").transform.position;

                //turning (also causes model to lean back a bit)
                if (Movement != Vector3.zero)
                {
                    players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").transform.forward = Movement;
                }

                //animations
                if (Movement.magnitude >= 0.03)
                {
                    Animators[i].Play("Walk");
                }
                else
                {
                    Animators[i].Play("Idle");
                }

                //buttons
                if (GamePadStates[i].IsConnected)
                {
                    //A (jumping)
                    GamePadStates[i] = GamePad.GetState(PlayerIndexes[i]);
                    if (GamePadStates[i].Buttons.A == ButtonState.Pressed)
                    {
                        Animators[i].Play("JumpHold");
                        Debug.Log("A Button was pressed!");
                    }

                    //B (dashing)
                    if (GamePadStates[i].Buttons.B == ButtonState.Pressed && !BwasPressed[i] && !GameIsPaused)
                    {
                        BwasPressed[i] = true;
                        Debug.Log("B Button was pressed!");
                        Vector3 boostDir = players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").transform.forward;
                        players[i].transform.Find("Player").transform.Find("metarig").transform.Find("hips").GetComponent<Rigidbody>().AddForce(boostDir * 10000f);
                    }
                    else if (GamePadStates[i].Buttons.B == ButtonState.Pressed && GameIsPaused)
                    {
                        if (PauseMenu.transform.Find("ControlImage").GetComponent<RawImage>().enabled)
                        {
                            PauseMenu.transform.Find("ControlImage").GetComponent<RawImage>().enabled = false;
                            PauseMenu.GetComponent<CanvasGroup>().interactable = true;
                        }
                        //else if (PauseMenu.enabled)
                        //{
                        //    PauseMenu.enabled = false;
                        //}
                    }
                    else if (GamePadStates[i].Buttons.B == ButtonState.Released && BwasPressed[i])
                    {
                        BwasPressed[i] = false;
                    }

                    //Y (respawning)
                    if (GamePadStates[i].Buttons.Y == ButtonState.Pressed && !YwasPressed[i])
                    {
                        YwasPressed[i] = true;
                        Debug.Log("Y Button was pressed!");
                        respawn(i);
                    }
                    else if (GamePadStates[i].Buttons.Y == ButtonState.Released && YwasPressed[i])
                    {
                        YwasPressed[i] = false;
                    }

                    //X (grabbing/throwing)
                    if (GamePadStates[i].Buttons.X == ButtonState.Pressed && !XwasPressed[i])
                    {
                        XwasPressed[i] = true;
                        Debug.Log("X Button was pressed!");
                        Grab(i);
                    }
                    else if (GamePadStates[i].Buttons.X == ButtonState.Released && XwasPressed[i])
                    {
                        XwasPressed[i] = false;
                    }

                    //Start (pausing)
                    if (GamePadStates[i].Buttons.Start == ButtonState.Pressed && !StartwasPressed[i] && !PauseMenu.enabled)
                    {
                        StartwasPressed[i] = true;
                        PauseMenu.enabled = true;
                        GameIsPaused = true;
                        PauseMenu.GetComponent<CanvasGroup>().interactable = true;
                        PauseMenu.transform.Find("Resume_Button").GetComponent<Button>().Select();
                        Time.timeScale = 0f;
                    }
                    else if (GamePadStates[i].Buttons.Start == ButtonState.Pressed && !StartwasPressed[i] && PauseMenu.enabled)
                    {
                        StartwasPressed[i] = true;
                        PauseMenu.enabled = false;
                        GameIsPaused = false;
                        PauseMenu.GetComponent<CanvasGroup>().interactable = false;
                        Time.timeScale = 1f;
                    }
                    else if (GamePadStates[i].Buttons.Start == ButtonState.Released && StartwasPressed[i])
                    {
                        StartwasPressed[i] = false;
                    }
                }
            }


        //TIME CHANGER
        //Updates any timers you want to use
        //dashes[i] corresponds to players[i]
        //staminas[i] corresponds to players[i]
        UpdateTimers();

            //^^^

            /*
            //Some previous attempts at turning
            float horizontalSpeed = 1f;
            if (players[0].transform.forward.x < Movement.x)
            {
                rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -H * horizontalSpeed / Time.deltaTime);
            }
            else
            {
                rotatePlayer1.RotateAround(pivot1.position, Vector3.up, H * horizontalSpeed / Time.deltaTime);
            }

            if (Movement.magnitude >= 0.03)
            {
                animator1.Play("Walk");
            }
            else
            {
                animator1.Play("Idle");
            }

            //float speed = 5f;
            //float step = speed * Time.deltaTime;
            //Vector3 newDir = Vector3.RotateTowards(players[0].transform.forward.normalized, Movement.normalized, step, 0.0f);
            //Debug.DrawRay(players[0].transform.position, newDir, Color.red);
            //players[0].transform.Find("Player").transform.rotation = Quaternion.LookRotation(newDir);


            //var lookat = Movement;
            //lookat.z = 0;
            //if (lookat.magnitude > 0)
            //{
            //    players[0].transform.Find("Player").transform.LookAt(players[0].transform.Find("Player").transform.position + lookat, players[0].transform.Find("Player").transform.forward);
            //}


            //if (players[0].transform.forward.x < Movement.x)
            //{
            //    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
            //}
            //else
            //{
            //    rotatePlayer1.RotateAround(pivot1.position, Vector3.up, -Mathf.Abs(players[0].transform.forward.x - Movement.x) * horizontalSpeed / Time.deltaTime);
            //}
            */

        }
        else {
            //join game
            if (Input.GetButtonDown("Start1")) {
                print("start1");
            }
            if (Input.GetButtonDown("Start2")) {
                print("Start2");
            }
            if (Input.GetButtonDown("Start3")) {
                print("Start3");
            }
            if (Input.GetButtonDown("Start4")) {
                print("Start4");
            }
        }
    }
}
//}