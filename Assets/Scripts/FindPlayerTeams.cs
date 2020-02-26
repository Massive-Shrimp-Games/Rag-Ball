using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerTeams : MonoBehaviour
{

    public List<GameObject> RedTeam = new List<GameObject>();
    public List<GameObject> BlueTeam = new List<GameObject>();

    //public List<GameObject> RedTeamHips = new List<GameObject>();
    //public List<GameObject> BlueTeamHips = new List<GameObject>();


    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.GetChild(0).GetComponent<Player>().color == TeamColor.Red)
            {
                RedTeam.Add(child.gameObject);
            }
            if (child.GetChild(0).GetComponent<Player>().color == TeamColor.Blue)
            {
                BlueTeam.Add(child.gameObject);
            }
        }

        /*foreach (GameObject gameObject in RedTeam)
        {
            if (gameObject.GetComponent<PlayerSize>().size == Size.Small)
            {
                RedTeamHips.Add(gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
            if (gameObject.GetComponent<PlayerSize>().size == Size.Medium)
            {
                RedTeamHips.Add(gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
            if (gameObject.GetComponent<PlayerSize>().size == Size.Large)
            {
                RedTeamHips.Add(gameObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
        }

        foreach (GameObject gameObject in BlueTeam)
        {
            if (gameObject.GetComponent<PlayerSize>().size == Size.Small)
            {
                BlueTeamHips.Add(gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
            if (gameObject.GetComponent<PlayerSize>().size == Size.Medium)
            {
                BlueTeamHips.Add(gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
            if (gameObject.GetComponent<PlayerSize>().size == Size.Large)
            {
                BlueTeamHips.Add(gameObject.transform.GetChild(2).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject);
            }
        }*/


    }
}
