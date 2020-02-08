using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public MenuItem defaultMenuItem;
    public Prefabber prefabber;
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
        GameObject cursor = prefabber.prefab;
        cursor.GetComponent<PlayerCursor>().currentMenuItem = defaultMenuItem;
        return Instantiate(cursor);
    }
}
