using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSize : MonoBehaviour
{
    // Start is called before the first frame update
    public Size size;
    public TeamColor color;
    public GameObject small;
    public GameObject medium;
    public GameObject large;
    private GameObject player;
    public int playerNumber;
    void Start()
    {
        if(Game.Instance == null) return;
        if(size == Size.Small)
        {
            small.SetActive(true);
            Destroy(medium);
            Destroy(large);
            transform.GetChild(0).GetChild(0).GetComponent<Player>().playerNumber = playerNumber;
            //small.GetComponent<Player>().color = color;
        } else if (size == Size.Medium)
        {
            medium.SetActive(true);
            Destroy(small);
            Destroy(large);
            transform.GetChild(0).GetChild(0).GetComponent<Player>().playerNumber = playerNumber;
            //medium.GetComponent<Player>().color = color;
        } else if (size == Size.Large)
        {
            large.SetActive(true);
            Destroy(small);
            Destroy(medium);
            transform.GetChild(0).GetChild(0).GetComponent<Player>().playerNumber = playerNumber;
            //large.GetComponent<Player>().color = color;
        }

    }
}
