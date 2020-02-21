using UnityEngine;

public class PlayerCursorFactory : MonoBehaviour
{
    public Prefabber prefabber;
    public MenuItem defaultMenuItem;
    public Transform parent;

    public GameObject CreateCursor(Transform canvas, int playerNumber, MenuItem defaultMenuItem)
    {
        prefabber.prefab.GetComponent<PlayerCursor>().currentMenuItem = defaultMenuItem;
        prefabber.prefab.GetComponent<PlayerCursor>().playerNumber = playerNumber;
        GameObject cursor = Instantiate(prefabber.prefab);
        cursor.name = string.Format("Cursor #{0}", playerNumber);
        cursor.transform.SetParent(canvas, false);
        return cursor;
    }

    private void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            CreateCursor(parent, i, defaultMenuItem);
        }
    }
}
