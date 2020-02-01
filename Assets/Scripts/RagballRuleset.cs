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

    public bool paused = false;
    public GameObject pauseMenu;
    private Controller pauseController;

    private void Start()
    {
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

    public void Pause(Controller controller)
    {
        pauseController = controller;
        pauseController.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
    }

    //RENAME ALL EVENTS AFTER MERGE
    private void StartMenu(InputValue inputValue)
    {

    }

    private void ProgressInMenu(InputValue inputValue)
    {

    }

    private void RegressInMenu(InputValue inputValue)
    {

    }

    private void BackToPreviousMenu(InputValue inputValue)
    {

    }
    /*
    private void MapControls()
    {
        if (pauseController != null)
        {
            pauseController._OnStartMenu += StartMenu;
            pauseController._OnProgressInMenu += ProgressInMenu;
            pauseController._OnRegressInMenu += RegressInMenu;
            pauseController._OnBackToPreviousMenu += BackToPreviousMenu;
        }
    }

    private void UnMapControls()
    {
        if (pauseController != null)
        {
            pauseController._OnStartMenu -= StartMenu;
            pauseController._OnProgressInMenu -= ProgressInMenu;
            pauseController._OnRegressInMenu -= RegressInMenu;
            pauseController._OnBackToPreviousMenu -= BackToPreviousMenu;
        }
    }
    */
}
