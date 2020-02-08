using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RagballRuleset : MonoBehaviour
{
    public delegate void Score(GameObject player,int score);

    public event Score OnRedScore;
    public event Score OnBlueScore;

    private int redScore = 0;
    private int blueScore = 0;

    public Transform respawnPoint;

    private void Start()
    {
        ActionMapEvent.InGameplay?.Invoke();
        OnRedScore += AddRedScore;
        OnBlueScore += AddBlueScore;
        //MapControls();
    }

    private void OnDestroy()
    {
        OnRedScore -= AddRedScore;
        OnBlueScore -= AddBlueScore;
        //UnMapControls();
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
    }
}
