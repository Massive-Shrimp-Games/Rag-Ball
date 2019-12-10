using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text TimerText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;


    void Start()
    {
        timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            TimerText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            TimerText.text = "0.00";
            timer = 0.0f;
            GameOver();
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
        if (RedScore >= WinScore)
        {
            RedWinScreen.enabled = true;
        }
        if (BlueScore >= WinScore)
        {
            BlueWinScreen.enabled = true;
        }
    }
}
