using UnityEngine;

public class PlayerCursorFactory : MonoBehaviour
{
    public Prefabber prefabber;

    public GameObject CreateCursor(Transform canvas, int playerNumber, MenuItem defaultMenuItem)
    {
        prefabber.prefab.GetComponent<PlayerCursor>().currentMenuItem = defaultMenuItem;
        prefabber.prefab.GetComponent<PlayerCursor>().playerNumber = playerNumber;
        GameObject cursor = Instantiate(prefabber.prefab);
        cursor.name = string.Format("Cursor #{0}", playerNumber);
        cursor.transform.SetParent(canvas, false);
        return cursor;
    }
}
