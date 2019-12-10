using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public int PlayerNumber = 1;
    public string PlayerColor;
    public ScoreManager scoremanager;
    public PlayerManager playermanager;

    public void Start()
    {
        Debug.Log("Johnny five is alive!\n And I am: " + PlayerColor);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("BUMP! I HIT SOMETHING!?!?!?!?!?\nAnd it was: " + other.gameObject.name);

        if (other.gameObject.name == "InvisibleGoalBlue")
        {
            scoremanager.AddBlueScore();
            playermanager.respawn(PlayerNumber);
            Debug.Log("OMG IT WAS A GOAL!!!!\n BLUE SCORES");
        }
        else if (other.gameObject.name == "InvisibleGoalRed")
        {
            scoremanager.AddRedScore();
            playermanager.respawn(PlayerNumber);
            Debug.Log("OMG IT WAS A GOAL!!!!\n RED SCORES");
        }

    /*
        if (other.GetComponent<GoalReply>().GoalColor == PlayerColor)
        {
            Debug.Log("OMG IT WAS A GOAL!!!!");

            if (PlayerColor == "red")
            {
                scoremanager.AddRedScore();
                playermanager.respawn(PlayerNumber);
            }
            else if (PlayerColor == "blue")
            {
                scoremanager.AddBlueScore();
                playermanager.respawn(PlayerNumber);
            }
        }
        else
        {
            Debug.Log("it wasnt a goal...");
        }*/
    }

}
