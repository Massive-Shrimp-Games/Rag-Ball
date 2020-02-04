using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CursorCreator : MonoBehaviour
{
    public MenuItem defaultItem;
    //public GameObject cursorPrefab;

    private List<PlayerCursor> cursors = new List<PlayerCursor>();
    public GameObject banner;
    public bool ready;
    public GameObject[] playerCursorPrefabs;

    private void Start()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            PlayerCursor cursor = Instantiate(playerCursorPrefabs[i]).GetComponent<PlayerCursor>();
            //cursor.transform.parent = transform.parent;
            cursor.transform.SetParent(transform);
            cursor.currentMenuItem = defaultItem;
            cursor.BindController(i);
            cursors.Add(cursor);
        }
        banner.SetActive(false);
    }

    private void Update()
    {
        ready = true;
        for (int i = 0; i < cursors.Count; i++)
        {
            if (cursors[i].active) {ready = false;}
        }

        if (ready) { banner.SetActive(true); }
        else { banner.SetActive(false); }
    }
}
