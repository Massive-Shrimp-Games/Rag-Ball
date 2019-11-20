using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
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

        Debug.Log("=====================\n===================\n====================");

        //Blue Score
        BlueScoreText = BlueScore.ToString();
        Debug.Log("WHERE IS THE SCORE!\n" + BlueScoreText);
        if (BlueScore < 10) BlueScoreText = "0" + BlueScoreText;
        bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;
        //Pause_bluescoreboard.GetComponent<TextMeshPro>().text = BlueScoreText;
    }

    public void AddRedScore()
    {
        RedScore += 1;
    }
    public void AddBlueScore()
    {
        BlueScore += 1;
        Debug.Log("We got the score!\n" + BlueScore);
    }
}
