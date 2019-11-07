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




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("THE GOAL HAS LOADED");
    }


    public int findPlayerNumber(GameObject myobject)
    {
        GameObject myparent = myobject.transform.parent.gameObject;
        if (myparent.name == "PlayerManager")
        {
            return myobject.GetComponent<PlayerModel>().PlayerNumber;
        }
        else
        {
            return findPlayerNumber(myobject.transform.parent.gameObject);
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        //Find type of player
        playernumber = findPlayerNumber(collision.gameObject);
        if (playernumber % 2 == 1)
        {
            playercolor = "blue";
        }
        else
        {
            playercolor = "red";
        }

        //if blue goal
        if ((goalcolor == "blue") && (playercolor == "blue"))
        {
            scoremanager.AddBlueScore();
            playermanager.respawn(playernumber);
        }

        //if red goal
        else if ((goalcolor == "red") && (playercolor == "red"))
        {
            scoremanager.AddRedScore();
            playermanager.respawn(playernumber);
        }


    }












}
