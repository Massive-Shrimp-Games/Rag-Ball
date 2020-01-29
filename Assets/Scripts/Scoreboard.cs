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

    private void OnScore(GameObject player, int score)
    {
        Debug.Log("Player Color: " + player.transform.root.GetChild(0).GetComponent<Player>().color + " with score " + score.ToString());

        if(player.transform.root.GetChild(0).GetComponent<Player>().color != color)
        {
            string scoreSTR = score.ToString();
            if (score < 10)
                scoreSTR = "0" + scoreSTR;
            scoreMesh.text = scoreSTR;
        }
        
    }
}
