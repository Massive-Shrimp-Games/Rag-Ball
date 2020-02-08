using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public PlayerCursorFactory playerCursorFactory;
    public MenuItem defaultMenuItem;

    public bool paused { get; private set; }
    private GameObject playerCursor;

    public void Pause(int playerNumber)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        paused = true;
        playerCursor = playerCursorFactory.CreateCursor(gameObject.transform, playerNumber, defaultMenuItem);
    }

    public void UnPause()
    {
        Destroy(playerCursor);
        Time.timeScale = 1f;
        gameObject.SetActive(false);
        paused = false;
    }
}
