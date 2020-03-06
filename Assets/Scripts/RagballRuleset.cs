using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RagballRuleset : MonoBehaviour
{

    public delegate void Score(GameObject player,int score);

    // Score Variables
    [Header("Score Variables")]
    public int redScore = 0;
    public int blueScore = 0;
    public event Score OnRedScore;
    public event Score OnBlueScore;

    public Transform respawnPoint;

    [SerializeField] private bool winState = false;
    public Animator transitionAnim;
    public ParticleSystem BlueConfetti;
    public ParticleSystem RedConfetti;
    public ParticleSystem ExitConfetti;

    // Fan Variables
    [Header("Fan Variables")]
    public bool FanEnabled = false;
    public GameObject Fan_Spinner;
    public GameObject Fan_Lever;
    private LeverToggle leverToggle;
    public Transform[] spawnPoints;

    // Pipe Moving Variables
    [Header("Pipe Variables")]
    public bool pipesMove = false;
    [SerializeField] private GameObject leftPipe;
    [SerializeField] private GameObject rightPipe;
    [SerializeField] private float pipeSpeed = 2;

    // Wall Removal Variables
    [Header("Wall Removal Variables")]
    public bool noWalls = false;
    public GameObject sceneWalls;
    public GameObject sceneColliders;
    public GameObject sceneSteps;

    private void Start()
    {
        if (Game.Instance == null) return;
        ActionMapEvent.InGameplay?.Invoke();
        OnRedScore += AddRedScore;
        OnBlueScore += AddBlueScore;
        transitionAnim.SetBool("Transition", false);

        Game.Instance.Music.StopAudio();

        // Fan Presence
        SpawnFan();

        // Pipe Movement
        EnablePipeMover();

        // Wall Removal
        RemoveWalls();

        //Game.Instance.Music.PlayAudio("game");
    }

    private void OnDestroy()
    {
        OnRedScore -= AddRedScore;
        OnBlueScore -= AddBlueScore;
    }
    public void RedScore(GameObject player)
    {
        //Debug.Log("Red goal score");
        if (winState == false)
        {
            OnRedScore(player, ++redScore);
        }
    }
    public void BlueScore(GameObject player)
    {
        if (winState == false)
        {
            OnBlueScore(player, ++blueScore);
        }
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
            winState = true;
            GameObject.Find("Timer").GetComponent<Timer>().canCount = false;
            StartCoroutine(WaitForTime());
        }
        if (winState == false && blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueConfetti.Play();
            RedConfetti.Play();
            ExitConfetti.Play();
            winState = true;
            GameObject.Find("Timer").GetComponent<Timer>().canCount = false;
            StartCoroutine(WaitForTime());
        }
        if (blueScore == redScore && blueScore == GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueConfetti.Play();
            RedConfetti.Play();
            ExitConfetti.Play();
            winState = true;
            GameObject.Find("Timer").GetComponent<Timer>().canCount = false;
            StartCoroutine(WaitForTime());
        }

        if (Input.GetKeyDown(KeyCode.R) == true)
        {
            SceneManager.LoadScene("Court");
        }
    }

    public IEnumerator WaitForTime()
    {
        GameObject.Find("Goal_AudioSource").GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(2);
        WinStateGame();
    }

    private void WinStateGame()
    {
        transitionAnim.SetBool("Transition", true);
        
    }

    /// <summary>
    /// This spawns a Lever and a Fan, binds the Fan to the Lever, and sets all states to ON
    /// </summary>
    private void SpawnFan()
    {
        if (FanEnabled)
        {
            // Spawn the Fan
            GameObject fan = Instantiate(Fan_Spinner);
            // Spawn the Lever
            GameObject fan_lever = Instantiate(Fan_Lever);

            // Move the fan into position
            fan.transform.position = spawnPoints[0].position;
            // Move the lever into position
            fan_lever.transform.position = spawnPoints[1].position;

            // Find the Lever Toggle
            leverToggle = fan_lever.transform.GetChild(1).GetComponent<LeverToggle>();

            // set the state of the lever to OFF
            leverToggle.leverState = false;

            // Add the Fan to the Lever's Children
            leverToggle.targetObjects.Add(fan.transform.GetChild(0).gameObject);
        }
    }

    /// <summary>
    /// Activates the `PipePingPong.cs` on the Goal Components
    /// </summary>
    private void EnablePipeMover()
    {
        if (pipesMove)
        {
            leftPipe.GetComponent<PipePingPong>().enabled = true;
            rightPipe.GetComponent<PipePingPong>().enabled = true;
            leftPipe.GetComponent<PipePingPong>().SetSpeed(pipeSpeed);
            rightPipe.GetComponent<PipePingPong>().SetSpeed(pipeSpeed);
        }
    }


    /// <summary>
    /// Removes all walls and hanging objects, instantiates a DEATHPLANE to catch players
    /// </summary>
    private void RemoveWalls()
    {
        if(noWalls)
        {
            // Remove Walls
            sceneWalls.SetActive(false);

            // Remove Colliders
            sceneColliders.SetActive(false);

            // Remove Steps
            sceneSteps.SetActive(false);
        }
    }
}
