using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROTHManager : MonoBehaviour
{
    public int P0Score;
    public int P1Score;
    public int P2Score;
    public int P3Score;
    public Text P0Text;
    
    // Start is called before the first frame update
    void Start()
    {
        ActionMapEvent.InGameplay?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        P0Text.text = P0Score.ToString();
    }

    public void P0AddScore(int ScoreValue)
    {
        P0Score += ScoreValue;
    }

    public void P1AddScore(int ScoreValue)
    {
        P1Score += ScoreValue;
    }

    public void P2AddScore(int ScoreValue)
    {
        P2Score += ScoreValue;
    }

    public void P3AddScore(int ScoreValue)
    {
        P3Score += ScoreValue;
    }
}
