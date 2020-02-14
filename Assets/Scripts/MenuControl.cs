using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public Animator cameraAnimator;
    public GameObject gameModeSelectMenu;
    public GameObject levelSelectMenu;
    public GameObject characterSelectMenu;
   
    private void Start()
    {
        MapCameraActions();
    }

    private void OnDestroy()
    {
        UnMapCameraActions();
    }

    private void MapCameraActions()
    {
        MenuActions._ToGameMode += ToGameMode;
        MenuActions._ToLevelSelect += ToLevelSelect;
        MenuActions._ToCharacterSelect += ToCharacterSelect;
    }

    private void UnMapCameraActions()
    {
        MenuActions._ToGameMode -= ToGameMode;
        MenuActions._ToLevelSelect -= ToLevelSelect;
        MenuActions._ToCharacterSelect -= ToCharacterSelect;
    }

    private void ToGameMode()
    {
        Debug.Log("Testingggggggggggg");
    }

    private void ToLevelSelect()
    {
        cameraAnimator.SetFloat("CamAnimate", 0.5f);
        gameModeSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    private void ToCharacterSelect()
    {
        Debug.Log("Testingggggggggggg33333333333");
    }
}
