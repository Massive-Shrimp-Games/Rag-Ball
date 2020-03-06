using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFactory : MonoBehaviour
{
    public Prefabber smallPrefabber;
    public Prefabber mediumPrefabber;
    public Prefabber largePrefabber;
    public Transform[] spawnPoints;
    public Transform parent;
    public GameObject CreatePlayer(int playerNumber, Transform spawnPoint, Transform parent, TeamColor color, RagdollSize size)
    {
        Prefabber prefabber = null;
        switch (size) {
            case RagdollSize.Small:
                prefabber = smallPrefabber;
                break;
            case RagdollSize.Medium:
                prefabber = mediumPrefabber;
                break;
            case RagdollSize.Large:
                prefabber = largePrefabber;
                break;
        }

        if (prefabber == null) return null;
        prefabber.prefab.transform.GetChild(0).GetComponent<Player>().size = size;
        prefabber.prefab.transform.GetChild(0).GetComponent<Player>().color = color;
        prefabber.prefab.transform.GetChild(0).GetComponent<Player>().playerNumber = playerNumber;
        GameObject player = Instantiate(prefabber.prefab);
        player.name = string.Format("Player #{0}", playerNumber);
        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        player.transform.parent = parent;
        return player;
    }

    private void Start()
    {
        if (Game.Instance == null) return;
        Init();
    }

    protected virtual void Init()
    {
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++) {
            CreatePlayer(i, spawnPoints[i], parent, CharacterSelect.playerSelections[i].color, CharacterSelect.playerSelections[i].size);
        }
    }
}
