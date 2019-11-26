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
    public ScoreManager scoremanager;
    public PlayerManager playermanager;
    public string goalcolor;

    public void OnTriggerEnter(Collider collision)
    {
        //Notify
        Debug.Log("Something entered a goal!");

        //if (collision.gameObject.GetComponent<PlayerModel>())
        //{
            //Notify
            Debug.Log("Player has entered a goal!");

            //if blue player
            //if (collision.gameObject.GetComponent<PlayerModel>().PlayerNumber % 2 == 1)
            //{
                //Notify
                Debug.Log("BLUE Player has entered a goal!");

                //if blue goal
                if (goalcolor == "blue")
                {
                    scoremanager.AddBlueScore();
                    Debug.Log("Blue Scores!");
                    //playermanager.respawn(players[collision.gameObject.GetComponent<PlayerModel>().PlayerNumber]);
                    Debug.Log("Respawn the player!");
                }
                //if red goal
                else
                {
                    Debug.Log("Bad Throw!");
                }

            //}
            //if red player
            //else if (collision.gameObject.GetComponent<PlayerModel>().PlayerNumber % 2 == 0)
            //{
                //Notify
                Debug.Log("RED Player has entered a goal!");

                //if blue goal
                if (goalcolor == "blue")
                {
                    Debug.Log("Bad Throw!");
                }
                //if red goal
                else
                {
                    scoremanager.AddRedScore();
                    Debug.Log("Red Scores!");
                    //playermanager.respawn(players[collision.gameObject.GetComponent<PlayerModel>().PlayerNumber]);
                    Debug.Log("Respawn the player!");
                }

            //}
            //else
            //{
            //    Debug.Log("Ick! Me no like whatever that was! BLEHHHHHHHHHH!");
            //}
            //SoundSource.Play();
        //}
    }
}
