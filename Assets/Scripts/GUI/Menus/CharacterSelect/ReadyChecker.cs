using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadyChecker : MonoBehaviour
{
    public GameObject letsGo;

    private GameObject bannerInstance;

    private void Start()
    {
        CharacterSelect.playerSelectionEvent += OnPlayerSelection;
    }

    private void OnDestroy()
    {
        CharacterSelect.playerSelectionEvent -= OnPlayerSelection;
    }

    private void OnPlayerSelection(CharacterSelectCursor cursor)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Cursor") && child.GetComponent<CharacterSelectCursor>().hasControl)
            {
                LetsNot(cursor);
                return;
            }
        }
        LetsGo();
    }

    private void LetsGo()
    {
        if (bannerInstance != null)
            return;
        GameObject banner = Instantiate(letsGo);
        banner.transform.SetParent(transform);
        banner.transform.position = transform.position;
        banner.transform.rotation = transform.rotation;
        banner.transform.localScale = new Vector3(1.8f,1.8f,1.8f);
        banner.name = "LetsGo";
        bannerInstance = banner;
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Cursor"))
            {
                child.GetComponent<CharacterSelectCursor>().letsGo = true;
            }
        }
    }

    private void LetsNot(CharacterSelectCursor cursor)
    {
        if (bannerInstance == null)
            return;
        Destroy(bannerInstance.gameObject);
        Debug.Log("LetsNot");
        cursor.letsGo = false;
    }
}
