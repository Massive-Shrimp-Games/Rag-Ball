using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPlayerTeams : MonoBehaviour
{

    public List<GameObject> RedTeam = new List<GameObject>();
    public List<GameObject> BlueTeam = new List<GameObject>();


    void Start()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.GetComponent<PlayerSize>().color == TeamColor.Red)
            {
                RedTeam.Add(child.gameObject);
            }
            if (child.GetComponent<PlayerSize>().color == TeamColor.Blue)
            {
                BlueTeam.Add(child.gameObject);
            }
        }
    }
}
