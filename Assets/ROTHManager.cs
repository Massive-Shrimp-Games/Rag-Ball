using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROTHManager : MonoBehaviour
{
    public int P1Score;
    public int P2Score;
    public int P3Score;
    public int P4Score;
    public Text P1Text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1Text.text = P1Score.ToString();
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

    public void P4AddScore(int ScoreValue)
    {
        P3Score += ScoreValue;
    }
}
