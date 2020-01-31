using System.Collections;
using System.Collections.Generic;
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
            c.GetComponent<Cursor>().currentMenuItem = defaultItem;
            c.GetComponent<Cursor>().BindController(i);
            c.transform.parent = parentCanvas.transform;
            c.GetComponent<Cursor>().currentMenuItem = defaultItem;
        }
    }
}
