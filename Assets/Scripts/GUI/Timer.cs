using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro TimerText;
    //[SerializeField] private float mainTimer;

    public int RedScore;
    public int BlueScore;
    public Canvas RedWinScreen;
    public Canvas BlueWinScreen;
    public ParticleSystem BluePipeConfetti;
    public ParticleSystem RedPipeConfetti;
    public ParticleSystem ExitPipeConfetti;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    void Start()
    {
        timer = GameModeSelect.timeLimit;
        timer = (timer * 60);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.FloorToInt(timer % 60);
            TimerText.text = min.ToString("00") + ":" + sec.ToString("00");
            
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            TimerText.text = ("00" + ":" + "00");
            timer = 0.0f;
            //GameOver();
        }
    }

    //void GameOver()
//    {      
//        //RedPipeConfetti.loop = true;
//        //BluePipeConfetti.loop = true;
//        ExitPipeConfetti.loop = true;
//        RedPipeConfetti.Play();
//        BluePipeConfetti.Play();
//        ExitPipeConfetti.Play();
//        if (RedScore >= BlueScore)
//        {
//            RedWinScreen.enabled = true;
//        }
//        if (BlueScore >= RedScore)
//        {
//            BlueWinScreen.enabled = true;
//        }
//    }
}
