using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RagballRuleset : MonoBehaviour
{
    public delegate void Score(GameObject player,int score);

    public event Score OnRedScore;
    public event Score OnBlueScore;

    public static int redScore = 0;
    public static int blueScore = 0;

    public Transform respawnPoint;

    private bool winState = false;
    public Animator transitionAnim;
    public ParticleSystem BlueConfetti;
    public ParticleSystem RedConfetti;
    public ParticleSystem ExitConfetti;

    private void Start()
    {
        ActionMapEvent.InGameplay?.Invoke();
        OnRedScore += AddRedScore;
        OnBlueScore += AddBlueScore;
        transitionAnim.SetBool("Transition", false);
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
            BlueConfetti.Play();
            RedConfetti.Play();
            ExitConfetti.Play();
            StartCoroutine(WaitForTime());
        }
        if (winState == false && blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueConfetti.Play();
            RedConfetti.Play();
            ExitConfetti.Play();
            StartCoroutine(WaitForTime());
        }
        if (RagballRuleset.blueScore == RagballRuleset.redScore && RagballRuleset.blueScore == GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueConfetti.Play();
            RedConfetti.Play();
            ExitConfetti.Play();
            StartCoroutine(WaitForTime());
        }
    }

    public IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(2);
        WinStateGame();
    }

    private void WinStateGame()
    {
        transitionAnim.SetBool("Transition", true);
        winState = true;
    }
}
