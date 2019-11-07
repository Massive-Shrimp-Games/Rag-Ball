using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This script is attached to an invisible goal
//The goal can detect if something hits it
//and compares the number of that thing (supposedly a player) and compares it with its internal color
//(In this case, it mods it by 2 to see if it is correct)

public class TriggerRespawn : MonoBehaviour
{
    public AudioSource SoundSource;
    public int playernumber;
    public ScoreManager scoremanager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerModel>())
        {
            if (collision.gameObject.GetComponent<PlayerModel>().PlayerNumber % 2 == 1)
            {
                scoremanager.AddBlueScore();
            }
            else
            {
                scoremanager.AddRedScore();
            }
            SoundSource.Play();
        }
    }
}
