using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshPro TimerText;
    [SerializeField] private float mainTimer;

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
            //GameOver();
            StartCoroutine(GameObject.Find("Ruleset").GetComponent<RagballRuleset>().WaitForTime());
        }
    }

    /*void GameOver()
    {      
        RedPipeConfetti.loop = true;
        BluePipeConfetti.loop = true;
        ExitPipeConfetti.loop = true;
        RedPipeConfetti.Play();
        BluePipeConfetti.Play();
        ExitPipeConfetti.Play();
        if (RedScore >= BlueScore)
        {
            RedWinScreen.enabled = true;
        }
        if (BlueScore >= RedScore)
        {
            BlueWinScreen.enabled = true;
        }
    }*/
}
