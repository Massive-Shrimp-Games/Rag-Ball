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

    private MenuType currentMenu;
   
    private void Start()
    {
        currentMenu = MenuType.GameModeSelect;
        MapCameraActions();
    }

    private void OnDestroy()
    {
        UnMapCameraActions();
    }

    private void MapCameraActions()
    {
        MenuActions._ToGameModeSelect += ToGameModeSelect;
        MenuActions._ToLevelSelect += ToLevelSelect;
        MenuActions._ToCharacterSelect += ToCharacterSelect;
    }

    private void UnMapCameraActions()
    {
        MenuActions._ToGameModeSelect -= ToGameModeSelect;
        MenuActions._ToLevelSelect -= ToLevelSelect;
        MenuActions._ToCharacterSelect -= ToCharacterSelect;
    }

    private void ToGameModeSelect()
    {
        currentMenu = MenuType.GameModeSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
        Instantiate();
        gameModeSelectMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
        characterSelectMenu.SetActive(false);
    }

    private void ToLevelSelect()
    {
        currentMenu = MenuType.LevelSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
        gameModeSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
        characterSelectMenu.SetActive(false);
    }

    private void ToCharacterSelect()
    {
        Debug.Log("testingCharSel");
        currentMenu = MenuType.CharacterSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
        gameModeSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        characterSelectMenu.SetActive(true);
    }
}
