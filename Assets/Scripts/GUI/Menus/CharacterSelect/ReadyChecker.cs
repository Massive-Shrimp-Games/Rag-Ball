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

    private void OnPlayerSelection(PlayerCursor cursor)
    {
        foreach (Transform child in transform)
        {
            if (child.name.Contains("Cursor") && child.GetComponent<PlayerCursor>().hasControl)
            {
                LetsNot();
                return;
            }
        }
        LetsGo();
    }

    private void LetsGo()
    {
        if (bannerInstance != null)
            return;
        Debug.Log("LetsGo");
        GameObject banner = Instantiate(letsGo);
        banner.transform.SetParent(transform);
        banner.name = "LetsGo";
        bannerInstance = banner;
    }

    private void LetsNot()
    {
        if (bannerInstance == null)
            return;
        Destroy(bannerInstance.gameObject);
        Debug.Log("LetsNot");
    }
}
