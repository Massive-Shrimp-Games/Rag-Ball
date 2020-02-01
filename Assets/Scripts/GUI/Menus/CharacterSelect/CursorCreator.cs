using UnityEngine;

public class CursorCreator : MonoBehaviour
{
    public MenuItem defaultItem;
    public GameObject cursorPrefab;

    void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            PlayerCursor cursor = Instantiate(cursorPrefab).GetComponent<PlayerCursor>();
            cursor.transform.parent = transform.parent;
            cursor.currentMenuItem = defaultItem;
            cursor.BindController(i);
        }
    }
}
