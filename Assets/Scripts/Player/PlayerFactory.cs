using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public Prefabber smallPrefabber;
    public Prefabber mediumPrefabber;
    public Prefabber largePrefabber;
    public Transform[] spawnPoints;
    public GameObject CreatePlayer(int playerNumber, Transform spawnPoint, TeamColor color, Size size)
    {
        Prefabber prefabber = null;
        switch (size) {
            case Size.Small:
                prefabber = smallPrefabber;
                break;
            case Size.Medium:
                prefabber = mediumPrefabber;
                break;
            case Size.Large:
                prefabber = largePrefabber;
                break;
        }

        if (prefabber == null) return null;
        prefabber.prefab.transform.GetChild(0).GetComponent<Player>().size = size;
        prefabber.prefab.transform.GetChild(0).GetComponent<Player>().color = color;
        GameObject player = Instantiate(prefabber.prefab);
        player.name = string.Format("Player #{0}", playerNumber);
        player.transform.position = spawnPoint.position;
        return player;
    }

    private void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++) {
            CreatePlayer(i, spawnPoints[i], TeamColor.Red, Size.Large);
        }
    }
}
