using UnityEngine;

public class CursorCreator : MonoBehaviour
{
    public PlayerCursorFactory playerCursorFactory;
    public MenuItem defaultMenuItem;

    private void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            playerCursorFactory.CreateCursor(gameObject.transform.parent, i, defaultMenuItem);
        }
    }
}
