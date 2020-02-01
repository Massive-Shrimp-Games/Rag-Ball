using UnityEngine;

public class CursorCreator : MonoBehaviour
{
    public GameObject parentCanvas;
    public MenuItem defaultItem;
    public GameObject[] cursorPrefabs;

    void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            GameObject c = Instantiate(cursorPrefabs[i]);
            c.GetComponent<PlayerCursor>().currentMenuItem = defaultItem;
            c.GetComponent<PlayerCursor>().BindController(i);
            c.transform.parent = parentCanvas.transform;
            c.GetComponent<PlayerCursor>().currentMenuItem = defaultItem;
        }
    }
}
