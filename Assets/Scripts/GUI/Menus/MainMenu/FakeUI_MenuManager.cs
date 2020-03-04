using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeUI_MenuManager : MonoBehaviour
{
    //public GameObject OneTakeObject;
    public Animator cameraAnimationChecker;
    private int CurrentMenuNumber = 0;
    [Header("Game Mode Menu Objects")]
    public Image FakeGMCursor;
    //All rect position placements for cursor:
    private RectTransform GMPosition;
    //All game mode canvases.
    public Text gamemodeTitle;
    public GameObject GameModeOne;
    public GameObject GameModeTwo;
    public GameObject GameModeThree;

    //
    public Text timerTitle;
    public Text TimerChanger;
    //
    public Text scoreTitle;
    public Text ScoreChanger;
    //
    public Text NextChanger;
    [Space(10)]
    //Check out this genius 1000iq play im gonna pull
    public Text REALMENUGamemode;
    public Text REALMENUTime;
    public Text REALMENUScore;
    public GameObject GMCursor;
    //I'm going to commit a crime using the cursor.
    [Space(10)]
    [Header("Level Select Menu Objects")]
    //All level select canvases
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
    //
    [Space(10)]
    public Text REALMENUCourt;
    public GameObject LVCursor;
    [Header("Character Select Menu Objects")]
    //all char sel canvases
    public GameObject CharacterSelectPlaceholder;

    // Start is called before the first frame update
    void Start()
    {
        //get all the menuItemManagers

        
        GMPosition = FakeGMCursor.GetComponent<RectTransform>();
        GMPosition.anchoredPosition3D = new Vector3(0, -79, 0);
        GMPosition.localScale = new Vector3((float)8.6241, (float)8.6241, (float)8.6241);
        //
        LSPosition = FakeLSCursor.GetComponent<RectTransform>();
        LSPosition.anchoredPosition3D = new Vector3(394, 354, 217);
        LSPosition.localScale = new Vector3((float)7.850089, (float)7.850089, (float)7.850089);
         

}

    // Update is called once per frame
    void Update()
    {
        //check menutype in camanimatorlol
        CurrentMenuNumber = cameraAnimationChecker.GetInteger("MenuType");
        if (CurrentMenuNumber == 0)
        {
            //GAMEMODE
            RectTransform rt = GMCursor.GetComponent<RectTransform>();
            FakeGMCursor.enabled = true;
            FakeLSCursor.enabled = false;
            //get those pogchamps ready
            if (rt.anchoredPosition.y > 0)
            {

                //Gamemode selection
                GMPosition.anchoredPosition3D = new Vector3(0, -79, 0);
                GMPosition.localScale = new Vector3((float)8.6241, (float)8.6241, (float)8.6241);

            } else if (rt.anchoredPosition.y < 0 && rt.anchoredPosition.y > -75)
            {
                //Timer
                GMPosition.anchoredPosition3D = new Vector3(180, -880, -187);
                GMPosition.localScale = new Vector3((float)5.049587, (float)7.837323, (float)7.837323);

            } else if (rt.anchoredPosition.y < -75 && rt.anchoredPosition.y > -400)
            {
                //Score
                GMPosition.anchoredPosition3D = new Vector3(-270, -1018, -260);
                GMPosition.localScale = new Vector3((float)6.697672, (float)6.993937, (float)10.39527);
            }
            else
            {
                //next
                GMPosition.anchoredPosition3D = new Vector3(89, -1419, -443);
                GMPosition.localScale = new Vector3((float)5.206972, (float)8.08639, (float)10.39527);
            }

            if (REALMENUGamemode.text == "RagBall")
            {
                //Middle box
                GameModeTwo.GetComponent<UnityEngine.UI.Text>().color = Color.white;
                //Others
                GameModeOne.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                GameModeThree.GetComponent<UnityEngine.UI.Text>().color = Color.black;


            } else if (REALMENUGamemode.text == "Rag of the Hill")
            {
                //Right Box
                GameModeThree.GetComponent<UnityEngine.UI.Text>().color = Color.white;
                //Others
                GameModeOne.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                GameModeTwo.GetComponent<UnityEngine.UI.Text>().color = Color.black;
                Debug.Log(rt.transform.position.y);
            }
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
            TimerChanger.text = REALMENUTime.text;
            ScoreChanger.text = REALMENUScore.text;
        }
        else if (CurrentMenuNumber == 1)
        {
            //Do level select checks here.
            FakeLSCursor.enabled = true;
            FakeGMCursor.enabled = false;
            RectTransform rt = LVCursor.GetComponent<RectTransform>();
            if (rt.anchoredPosition.y > -420)
            {
                //court
                LSPosition.anchoredPosition3D = new Vector3(394, 354, 217);
                LSPosition.localScale = new Vector3((float)7.850089, (float)7.850089, (float)7.850089);
            } else{
                LSPosition.anchoredPosition3D = new Vector3(756, -272, 192);
                LSPosition.localScale = new Vector3((float)5.473788, (float)7.850089, (float)7.850089);
            }

            //Check for which menu was picked in previous selection.

            if (REALMENUGamemode.text == "RagBall")
            {
                //Ragball mode.
                PlaceholderCourt1Img.enabled = false;
                RoTH_Court1Img.enabled = false;
                if (REALMENUCourt.text == "Court 1")
                {
                    //Og Court. 
                    CourtChanger.text = REALMENUCourt.text;
                    RB_Court1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }
                else if (REALMENUCourt.text == "Court 2")
                {
                    //Second court (currently placeholder)
                    CourtChanger.text = REALMENUCourt.text;
                    RB_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                } // so and and so forth... this can be expanded for as many courts are added.
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    RB_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                    //If there's no setting in the fake menu manager for a new court, it will display a question mark. :)
                }

            }
            else if (REALMENUGamemode.text == "Rag of the Hill")
            {
                //RoTH Game mode.
                PlaceholderCourt1Img.enabled = false;
                RB_Court1Img.enabled = false;
                if (REALMENUCourt.text == "Court 1")
                {
                    //OG Sandcastle.
                    CourtChanger.text = REALMENUCourt.text;
                    RoTH_Court1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }
                else if (REALMENUCourt.text == "Court 2")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    RoTH_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                }
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    RoTH_Court1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                }
            }
            else
            {
                //Capture The Rag, currently. 
                RoTH_Court1Img.enabled = false;
                RB_Court1Img.enabled = false;
                if (REALMENUCourt.text == "Court 1")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    PlaceholderCourt1Img.enabled = true;
                    PlaceholderCourt2Img.enabled = false;
                    UnknownCourtImg.enabled = false;
                }
                else if (REALMENUCourt.text == "Court 2")
                {
                    CourtChanger.text = REALMENUCourt.text;
                    PlaceholderCourt1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = true;
                    UnknownCourtImg.enabled = false;
                }
                else
                {
                    CourtChanger.text = REALMENUCourt.text;
                    UnknownCourtImg.enabled = true;
                    PlaceholderCourt1Img.enabled = false;
                    PlaceholderCourt2Img.enabled = false;
                }
            }
        }
            
            //else
            //{
            //Do char Sel checks here. Only necessary if charsel choices come up
            //}



            //check gameobjects to see whats currently highlighted


            //check values to see whats currently inputed


            //Change vals / highlights accordingly

        }
    }



