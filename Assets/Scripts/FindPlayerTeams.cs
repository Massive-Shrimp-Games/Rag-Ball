using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerTeams : MonoBehaviour
{

    public List<GameObject> RedTeam = new List<GameObject>();
    public List<GameObject> BlueTeam = new List<GameObject>();

    public List<GameObject> RedTeamHips = new List<GameObject>();
    public List<GameObject> BlueTeamHips = new List<GameObject>();


    void Start()
    {
        foreach (Player player in FindObjectsOfType<Player>())
        {
            if (player.color == TeamColor.Red)
            {
                RedTeam.Add(player.transform.gameObject);
            }
            if (player.color == TeamColor.Blue)
            {
                BlueTeam.Add(player.transform.gameObject);
            }
        }

        foreach (GameObject player in RedTeam)
        {
            RedTeamHips.Add(player.GetComponent<Player>().getHips());
        }

        foreach (GameObject player in BlueTeam)
        {
            BlueTeamHips.Add(player.GetComponent<Player>().getHips());
        }
    }
}
