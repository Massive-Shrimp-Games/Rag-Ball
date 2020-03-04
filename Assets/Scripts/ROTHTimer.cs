using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ROTHTimer : MonoBehaviour
{
    [SerializeField] private TextMeshPro TimerText;
    //[SerializeField] private float mainTimer;

    //public int RedScore;
    //public int BlueScore;
    public TextMeshProUGUI WinText;

    private float timer;
    public bool canCount = true;
    private bool doOnce = false;
    [SerializeField] private ROTHManager manager;


    void Start()
    {
        timer = GameModeSelect.timeLimit;
        timer = (timer * 60);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer > 0.0f)
        {
            timer -= Time.deltaTime;
            int min = Mathf.FloorToInt(timer / 60);
            int sec = Mathf.FloorToInt(timer % 60);
            TimerText.text = min.ToString("00") + " : " + sec.ToString("00");
        }

        else if (timer <= 0.0f && !doOnce)
        {
            Debug.Log("Timer <= 0");
            doOnce = true;
            TimerText.text = ("00" + " : " + "00");
            timer = 0.0f;
            //GameObject.Find("Goal_AudioSource").GetComponent<AudioSource>().Play();
            GameOver();
        }
    }
    void GameOver()
    {
        Debug.Log("GameOverCalled");
        int winner = 0;
        int highestScore = 0;
        for(int i = 0; i < manager.scores.Length; i++)
        {
            if (manager.scores[i] > highestScore)
            {
                highestScore = manager.scores[i];
                winner = i;
            }
        }
        winner = winner + 1;
        WinText.text = "Player " + winner.ToString() + " Wins!";
        manager.endCanv.SetActive(true);
        ActionMapEvent.InMenu?.Invoke();
        //WinText.enabled = true;
    }
}