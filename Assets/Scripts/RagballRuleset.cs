using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagballRuleset : MonoBehaviour
{
    public delegate void Score(GameObject player,int score);

    public event Score OnRedScore;
    public event Score OnBlueScore;

    private int redScore = 0;
    private int blueScore = 0;

    public Transform respawnPoint;

    private bool winState = false;
    public GameObject RedWin;
    public GameObject BlueWin;
    public GameObject TieWin;

    private void Start()
    {
        OnRedScore += AddRedScore;
        OnBlueScore += AddBlueScore;
        RedWin.SetActive(false);
        BlueWin.SetActive(false);
        TieWin.SetActive(false);
    }

    private void OnDestroy()
    {
        OnRedScore -= AddRedScore;
        OnBlueScore -= AddBlueScore;
    }
    public void RedScore(GameObject player)
    {
        //Debug.Log("Red goal score");
        OnRedScore(player, ++redScore);
    }
    public void BlueScore(GameObject player)
    {
        OnBlueScore(player, ++blueScore);
    }
    private void AddRedScore(GameObject player, int score)
    {
        //redScore++;
        player.transform.position = respawnPoint.transform.position;
    }

    private void AddBlueScore(GameObject player, int score)
    {
        //blueScore++;
        player.transform.position = respawnPoint.transform.position;
        //player.transform.GetComponent<Player>().ResetVelocity();
    }

    private void Update()
    {
        if (winState == false && redScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            RedWin.SetActive(true);
            winState = true;
        }
        if (winState == false && blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueWin.SetActive(true);
            winState = true;
        }
    }
}
