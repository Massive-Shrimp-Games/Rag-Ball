using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagOfTheHill : MonoBehaviour
{
    //public GameObject player;

    public float[] playerTimers;

    public int pointValue;

    [SerializeField] private float originalTimer;

    [SerializeField] private ROTHManager roth;
    // Start is called before the first frame update
    void Start()
    {
        if (Game.Instance == null) return;
        playerTimers = new float[Game.Instance.Controllers.Count()];
        for (int i = 0; i < playerTimers.Length; i++)
        {
            playerTimers[i] = originalTimer;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Game.Instance == null) return;
        BaseObject b = other.GetComponent<BaseObject>();
        if (b != null)
        {
            if (playerTimers[b.player.playerNumber] >= 0.0f)
            {
                playerTimers[b.player.playerNumber] -= Time.deltaTime;
            }
            if (playerTimers[b.player.playerNumber] <= 0.0f)
            {
                playerTimers[b.player.playerNumber] = originalTimer;
                roth.addScore(b.player.playerNumber, pointValue);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        BaseObject b = other.GetComponent<BaseObject>();
        if (b != null)
        {
            playerTimers[b.player.playerNumber] = originalTimer;
        }
    }
}
