using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    // Variables
    //public GameObject RedGoal;
    //public GameObject BlueGoal;
    public int RedScore;
    public int BlueScore;
    public int WinScore = 5;
    public GameObject redscoreboard;
    public GameObject bluescoreboard;
    public GameObject Pause_redscoreboard;
    public GameObject Pause_bluescoreboard;
    public string BlueScoreText;
    public string RedScoreText;
    public Canvas RedWinScreen;
    public Canvas BlueWinScreen;


    // Start is called before the first frame update
    void Start()
    {
        RedScore = 00;
        BlueScore = 00;
    }

    // Update is called once per frame
    void Update()
    {
        //Red Score
        RedScoreText = RedScore.ToString();
        if (RedScore < 10) RedScoreText = "0" + RedScoreText;
        redscoreboard.GetComponent<TextMeshPro>().text = RedScoreText;
        //Pause_redscoreboard.GetComponent<TextMeshPro>().text = RedScoreText;

        //Debug.Log("=====================\n===================\n====================");

        //Blue Score
        BlueScoreText = BlueScore.ToString();
        //Debug.Log("WHERE IS THE SCORE!\n" + BlueScoreText);
        if (BlueScore < 10) BlueScoreText = "0" + BlueScoreText;
        bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;
        //Pause_bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;
    }

    public void AddRedScore()
    {
        RedScore += 1;
        if (RedScore >= WinScore)
        {
            RedWinScreen.enabled = true;
            Debug.Log("RED WINS");
        }
    }
    public void AddBlueScore()
    {
        BlueScore += 1;
        if (BlueScore >= WinScore)
        {
            BlueWinScreen.enabled = true;
            Debug.Log("BLUE WINS");
        }
    }
}
