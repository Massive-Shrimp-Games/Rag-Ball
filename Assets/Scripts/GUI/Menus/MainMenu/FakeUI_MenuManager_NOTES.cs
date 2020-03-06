using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeUI_MenuManager_NOTES : MonoBehaviour
{




    // *****************************
    // BOTH
    // *****************************

    // public GameObject OneTakeObject;
    public Animator cameraAnimationChecker;
    private int CurrentMenuNumber = 0;





    // ********************************
    // GAME MODE
    // ********************************

    // GM: Inspector UI
    [Header("Game Mode Menu Objects")]
    public Image FakeGMCursor;

    // GM: Purple Cursor
    private RectTransform GMPosition;

    // GM: Canvases
    public Text gamemodeTitle;
    public GameObject GameModeOne;      // Left Box
    public GameObject GameModeTwo;      // Middle Box
    public GameObject GameModeThree;    // Right Box

    // GM: Timer
    public Text timerTitle;
    public Text TimerChanger;

    // GM: Score
    public Text scoreTitle;
    public Text ScoreChanger;

    // GM: Next
    public Text NextChanger;
    [Space(10)]

    // Check out this genius 1000iq play im gonna pull
    public Text REALMENUGamemode;
    public Text REALMENUTime;
    public Text REALMENUScore;
    public GameObject GMCursor;






    // *******************
    // LEVEL SELECT
    // *******************

    // LS: Inspector UI
    [Space(10)]
    [Header("Level Select Menu Objects")]

    // LS: Canvases
    public Image FakeLSCursor;
    private RectTransform LSPosition;
    public Text CourtSelectTitle;
    public Text CourtChanger;
    public Image PlaceholderCourt1Img;
    public Image PlaceholderCourt2Img;
    public RawImage UnknownCourtImg;
    public RawImage RB_Court1Img;
    public RawImage RoTH_Court1Img;
    public Image FancyNextImg;   

    // LS: ???
    [Space(10)]
    public Text REALMENUCourt;
    public GameObject LVCursor;
    [Header("Character Select Menu Objects")]

    //all char sel canvases
    public GameObject CharacterSelectPlaceholder;

    






    /// <summary>
    /// Set the default values for the purple cursors (GM and LS)
    /// </summary>
    void Start()
    {
        // Setup GameSelect
        GMPosition = FakeGMCursor.GetComponent<RectTransform>();
        GMPosition.anchoredPosition3D = new Vector3(0, -79, 0);
        GMPosition.localScale = new Vector3((float)8.6241, (float)8.6241, (float)8.6241);

        // Setup LevelSelect
        LSPosition = FakeLSCursor.GetComponent<RectTransform>();
        LSPosition.anchoredPosition3D = new Vector3(394, 354, 217);
        LSPosition.localScale = new Vector3((float)7.850089, (float)7.850089, (float)7.850089);
    }







    /// <summary>
    /// Oh god Lisa why did you do this to us?!?!?!?
    /// </summary>
    void Update()
    {
        // check menutype in camanimatorlol
        CurrentMenuNumber = cameraAnimationChecker.GetInteger("MenuType");



        // ****************
        // GAME MODE
        // ****************
        if (CurrentMenuNumber == 0)
        {
            // ALL: Enable GMpurpleCursor, Disable LSpurpleCursor
            RectTransform rt = GMCursor.GetComponent<RectTransform>();
            FakeGMCursor.enabled = true;
            FakeLSCursor.enabled = false;

            // GM: GAMEMODE
            if (rt.anchoredPosition.y > 0)
            {
                // Move purpleCursor to GameModeText
                GMPosition.anchoredPosition3D = new Vector3(0, -79, 0);
                GMPosition.localScale = new Vector3((float)8.6241, (float)8.6241, (float)8.6241);

            }

            // GM: TIMER
            else if (rt.anchoredPosition.y < 0 && rt.anchoredPosition.y > -75)
            {
                // Move purpleCursor to TimerText
                GMPosition.anchoredPosition3D = new Vector3(180, -880, -187);
                GMPosition.localScale = new Vector3((float)5.049587, (float)7.837323, (float)7.837323);

            }

            // GM: SCORE
            else if (rt.anchoredPosition.y < -75 && rt.anchoredPosition.y > -400)
            {
                // Move purpleCursor to ScoreText
                GMPosition.anchoredPosition3D = new Vector3(-300, -1018, -260);
                GMPosition.localScale = new Vector3((float)4.697672, (float)6.993937, (float)10.39527);
            }

            // GM: NEXT
            else
            {
                // Move purpleCursor to NextText
                GMPosition.anchoredPosition3D = new Vector3(89, -1419, -443);
                GMPosition.localScale = new Vector3((float)5.206972, (float)8.08639, (float)10.39527);
            }


            // ************
            // UNKNOWN
            // ************

            // GM: ???
            if (REALMENUGamemode.text == "RagBall")
            {
                //Middle box
                GameModeTwo.GetComponent<UnityEngine.UI.Text>().color = Color.white;
                //Others
                GameModeOne.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                GameModeThree.GetComponent<UnityEngine.UI.Text>().color = Color.black;


            }

            // GM: ???
            else if (REALMENUGamemode.text == "Rag of the Hill")
            {
                //Right Box
                GameModeThree.GetComponent<UnityEngine.UI.Text>().color = Color.white;
                //Others
                GameModeOne.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                GameModeTwo.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                Debug.Log(rt.transform.position.y);
            }

            // GM: ???
            else
            {
                //Left Box
                GameModeOne.GetComponent<UnityEngine.UI.Text>().color = Color.white;
                //Others
                GameModeTwo.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                GameModeThree.GetComponent<UnityEngine.UI.Text>().color = Color.black;
            }


            //do your checks for Game Mode Selects Here.
            //Use to test: gamemodeTitle.text = REALMENUGamemode.text;

            // **************
            // UNKNOWN
            // **************

            // GM: ???
            if (REALMENUTime.text == "No Limit" || REALMENUTime.text == "No Limits")
            {
                TimerChanger.text = "--:--";
            }

            // GM: ???
            else
            {
                TimerChanger.text = (REALMENUTime.text + ":00");
            }

            // GM: ???
            if (REALMENUScore.text == "No Limit"){
                ScoreChanger.text = "X";
            }

            // GM: ???
            else
            {
                ScoreChanger.text = REALMENUScore.text;
            }
            
        }








        // ****************
        // LEVEL SELECT
        // ****************
        else if (CurrentMenuNumber == 1)
        {
            // Do level select checks here.
            FakeLSCursor.enabled = true;
            FakeGMCursor.enabled = false;
            RectTransform rt = LVCursor.GetComponent<RectTransform>();


            // LS: ???
            if (rt.anchoredPosition.y > -420)
            {
                //court
                LSPosition.anchoredPosition3D = new Vector3(394, 354, 217);
                LSPosition.localScale = new Vector3((float)7.850089, (float)7.850089, (float)7.850089);
            }

            // LS: ???
            else {
                LSPosition.anchoredPosition3D = new Vector3(756, -272, 192);
                LSPosition.localScale = new Vector3((float)5.473788, (float)7.850089, (float)7.850089);
            }

            // LS: RagBall GameMode
            if (REALMENUGamemode.text == "RagBall")
            {
                // LS: Ragball mode.
                PlaceholderCourt1Img.enabled = false;
                RoTH_Court1Img.enabled = false;

                // LS: Og Court. 
                if (REALMENUCourt.text == "Court 1")
                {
                    // ???
                    CourtChanger.text = REALMENUCourt.text;
                    RB_Court1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }

                // LS: Second court (currently placeholder)
                else if (REALMENUCourt.text == "Court 2")
                {
                    // ???
                    CourtChanger.text = REALMENUCourt.text;
                    RB_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                    // so and and so forth... this can be expanded for as many courts are added.
                }

                // LS: Random Court
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    RB_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                    //If there's no setting in the fake menu manager for a new court, it will display a question mark. :)
                }

            }

            // LS: RagoftheHill GameMode
            else if (REALMENUGamemode.text == "Rag of the Hill")
            {
                //RoTH Game mode.
                PlaceholderCourt1Img.enabled = false;
                RB_Court1Img.enabled = false;

                // LS: OG Sandcastle.
                if (REALMENUCourt.text == "Court 1")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    RoTH_Court1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }

                // LS: ???
                else if (REALMENUCourt.text == "Court 2")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    RoTH_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                }

                // LS: ???
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    RoTH_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                }
            }

            // LS: CapturetheRag GameMode
            else
            {
                //Capture The Rag, currently. 
                RoTH_Court1Img.enabled = false;
                RB_Court1Img.enabled = false;

                // LS: ???
                if (REALMENUCourt.text == "Court 1")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    PlaceholderCourt1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }

                // LS: ???
                else if (REALMENUCourt.text == "Court 2")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    PlaceholderCourt1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                }

                // LS: ???
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    PlaceholderCourt1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                }
            }
        }

        // ****************
        // UNKNOWN
        // ****************
            
            //else
            //{
            //Do char Sel checks here. Only necessary if charsel choices come up
            //}



            //check gameobjects to see whats currently highlighted


            //check values to see whats currently inputed


            //Change vals / highlights accordingly

        }
    }



