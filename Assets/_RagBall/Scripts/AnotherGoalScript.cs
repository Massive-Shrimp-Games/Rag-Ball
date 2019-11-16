using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnotherGoalScript : MonoBehaviour
{

    public ScoreManager scoremanager;
    public PlayerManager playermanager;
    public string goalcolor;
    private int playernumber;
    private string playercolor;
    public GameObject audiomanager;
    public ParticleSystem Confetti;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THE GOAL HAS LOADED");
    }


    public int findPlayerNumber(GameObject myobject)
    {
        Debug.Log("Looking for the number!");
        GameObject myparent = myobject.transform.parent.gameObject;
        if (myparent.name == "Player1")
        {
            Debug.Log("Found 1");
            return 0;
        }
        else if (myparent.name == "Player2")
        {
            Debug.Log("Found 2");
            return 1;
        }
        else if (myparent.name == "Player3")
        {
            Debug.Log("Found 3");
            return 2;
        }
        else if (myparent.name == "Player4")
        {
            Debug.Log("Found 4");
            return 3;
        }
        else
        {
            Debug.Log("Found NONE");
            return findPlayerNumber(myobject.transform.parent.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Find type of player
        playernumber = findPlayerNumber(collision.gameObject);
        if (playernumber % 2 == 1)
        {
            Debug.Log("Player is BLUE");
            playercolor = "blue";
        }
        else
        {
            Debug.Log("Player is RED");
            playercolor = "red";
        }

        //if blue goal
        if ((goalcolor == "blue") && (playercolor == "blue"))
        {
            Debug.Log("===== BLUE SCORES =====");
            scoremanager.AddBlueScore();
            playermanager.respawn(playernumber);
        }

        //if red goal
        else if ((goalcolor == "red") && (playercolor == "red"))
        {
            Debug.Log("===== RED SCORES =====");
            scoremanager.AddRedScore();
            playermanager.respawn(playernumber);
        }

        //play goal audio
        audiomanager.transform.Find("Goal_AudioSource").GetComponent<AudioSource>().Play();


    }












}
