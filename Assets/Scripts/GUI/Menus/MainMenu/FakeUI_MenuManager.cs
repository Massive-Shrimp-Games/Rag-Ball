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
    public GameObject LevelSelectPlaceholder;
    [Header("Character Select Menu Objects")]
    //all char sel canvases
    public GameObject CharacterSelectPlaceholder;

    // Start is called before the first frame update
    void Start()
    {
        //get all the menuItemManagers
        


    }

    // Update is called once per frame
    void Update()
    {
        //check menutype in camanimatorlol
        CurrentMenuNumber = cameraAnimationChecker.GetInteger("MenuType");
        if (CurrentMenuNumber == 0)
        {
            RectTransform rt = GMCursor.GetComponent<RectTransform>();

            //get those pogchamps ready
            if (rt.anchoredPosition.y > 0)
            {
                //Gamemode selection
                gamemodeTitle.color = Color.magenta;
                //else
                timerTitle.color = Color.black;
                scoreTitle.color = Color.black;
               

            } else if (rt.anchoredPosition.y < 0 && rt.anchoredPosition.y > -75)
            {
                //Timer
                timerTitle.color = Color.magenta;
                //
                scoreTitle.color = Color.black;
                gamemodeTitle.color = Color.black;
                
            } else if (rt.anchoredPosition.y < -75 && rt.anchoredPosition.y > -400)
            {
                //Score
                scoreTitle.color = Color.magenta;
                //
                timerTitle.color = Color.black;
                gamemodeTitle.color = Color.black;
                
            }
            else
            {
                timerTitle.color = Color.black;
                gamemodeTitle.color = Color.black;
                scoreTitle.color = Color.black;
                //next
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
