using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public MenuItem defaultMenuItem;
    public Prefab prefab;
    public bool paused { get; private set; }
    private GameObject playerCursor;

    public void Pause(int playerNumber)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        paused = true;
        playerCursor = CreateCursor(playerNumber);
        playerCursor.transform.parent = gameObject.transform;
    }

    public void UnPause()
    {
        Destroy(playerCursor);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        paused = false;
    }

    private GameObject CreateCursor(int playerNumber)
    {
        prefab.prefab.GetComponent<PlayerCursor>().currentMenuItem = defaultMenuItem;
        return Instantiate(prefab.prefab);
    }
}
