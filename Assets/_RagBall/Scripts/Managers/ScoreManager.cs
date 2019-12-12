using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshPro TimerText;
    [SerializeField] private float mainTimer;

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
    public Canvas TieWinScreen;
    public ParticleSystem BluePipeConfetti;
    public ParticleSystem RedPipeConfetti;
    public ParticleSystem ExitPipeConfetti;

    public float Seconds = 0;
    public float Minutes = 5;
    public bool doOnce = false;

    private bool CanAddScore = true;


    // Start is called before the first frame update
    void Start()
    {
        RedScore = 00;
        BlueScore = 00;
        WinScore = CustomizationManager.CM.GoalsMax;
        Minutes = CustomizationManager.CM.TimerMax;
        
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

        if (BlueWinScreen.enabled || RedWinScreen.enabled || TieWinScreen.enabled)
        {
            CanAddScore = false;
        }

        if (Seconds <= 0)
        {
            Seconds = 59;
            if (Minutes >= 1)
            {
                Minutes--;
            }
            else
            {
                Minutes = 0;
                Seconds = 0;
                TimerText.text = Minutes.ToString("f0") + Seconds.ToString("f0");
            }
        }
        else
        {
            Seconds -= Time.deltaTime;
        }
        if(Mathf.Round(Seconds) <= 0)
        {
            TimerText.text = Minutes.ToString("f0") + ":0" + Seconds.ToString("f0");
        }
        else
        {
            TimerText.text = Minutes.ToString("f0") + ":" + Seconds.ToString("f0");
        }
        if (Seconds <= 0.0f && !doOnce && Minutes <= 0.0f)
        {
            doOnce = true;        
            GameOver();
        }
    }

    public void AddRedScore()
    {
        if (CanAddScore)
        {
            RedScore += 1;
        }
    
        if (RedScore >= WinScore)
        {
            RedWinScreen.enabled = true;
            RedPipeConfetti.loop = true;
            BluePipeConfetti.loop = true;
            ExitPipeConfetti.loop = true;
            RedPipeConfetti.Play();
            BluePipeConfetti.Play();
            ExitPipeConfetti.Play();
            Debug.Log("RED WINS");
        }
    }
    public void AddBlueScore()
    {
        if (CanAddScore)
        {
            BlueScore += 1;
        }

        if (BlueScore >= WinScore)
        {
            BlueWinScreen.enabled = true;
            RedPipeConfetti.loop = true;
            BluePipeConfetti.loop = true;
            ExitPipeConfetti.loop = true;
            RedPipeConfetti.Play();
            BluePipeConfetti.Play();
            ExitPipeConfetti.Play();
            Debug.Log("BLUE WINS");
        }
    }

    void GameOver()
    {
        RedPipeConfetti.loop = true;
        BluePipeConfetti.loop = true;
        ExitPipeConfetti.loop = true;
        RedPipeConfetti.Play();
        BluePipeConfetti.Play();
        ExitPipeConfetti.Play();
        if (RedScore > BlueScore)
        {
            RedWinScreen.enabled = true;
        }
        if (BlueScore > RedScore)
        {
            BlueWinScreen.enabled = true;
        }
        if (RedScore == BlueScore)
        {
            TieWinScreen.enabled = true;
        }
    }
}
