using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public TeamColor color;
    private RagballRuleset ruleset;
    private TextMeshPro scoreMesh;

    private void Start()
    {
        ruleset = GameObject.Find("Ruleset")?.GetComponent<RagballRuleset>();
        scoreMesh = transform.GetChild(2)?.GetComponent<TextMeshPro>();
        Debug.Log("Scoreboard start");
        if (color == TeamColor.Red)
        {
            ruleset.OnRedScore += OnScore;
        }
        else if (color == TeamColor.Blue)
        {
            ruleset.OnBlueScore += OnScore;
        }
    }

    private void OnDestroy()
    {
        if (color == TeamColor.Red)
        {
            ruleset.OnRedScore -= OnScore;
        }
        else if (color == TeamColor.Blue)
        {
            ruleset.OnBlueScore -= OnScore;
        }
    }

    private void OnScore(GameObject player)
    {
        Debug.Log("OnScore");
        if (color == TeamColor.Red)
        {
            string score = ruleset.GetRedScore().ToString();
            if(ruleset.GetRedScore() < 10)
                score = "0" + score;
            scoreMesh.text = score;
        }
        else if (color == TeamColor.Blue)
        {
            //Debug.LogFormat("Score is {0}", ruleset.GetBlueScore().ToString());
            string score = ruleset.GetBlueScore().ToString();
            if(ruleset.GetBlueScore() < 10)
                score = "0" + score;
            scoreMesh.text = score;
            
            //scoreMesh.SetText(ruleset.GetBlueScore().ToString());
        }
    }
}
