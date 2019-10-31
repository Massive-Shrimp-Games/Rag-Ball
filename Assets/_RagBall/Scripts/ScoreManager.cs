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
    public int BlueLayer;
    public int RedLayer;
    public TextMeshProUGUI BlueScoreText;
    public TextMeshProUGUI RedScoreText;

    // Start is called before the first frame update
    void Start()
    {
        RedScore = 0;
        BlueScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        RedScoreText.text = RedScore.ToString();
        BlueScoreText.text = BlueScore.ToString();
    }

    public void AddScore(int Layer)
    {
        if (Layer == RedLayer)
        {
            RedScore += 1;
        }
        else if (Layer == BlueLayer)
        {
            BlueScore += 1;
        }
    }
}
