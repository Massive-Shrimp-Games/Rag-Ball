using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class MenuControl : MonoBehaviour
{
    
    public Animator cameraAnimator;
    public GameObject gameModeSelectMenu;
    public GameObject levelSelectMenu;
    public GameObject characterSelectMenu;
    public PostProcessVolume ppVol;
    DepthOfField depthLayer = null;
    private MenuType currentMenu;
   
    private void Start()
    {
        currentMenu = MenuType.GameModeSelect;
        MapCameraActions();
        ppVol = gameObject.GetComponent<PostProcessVolume>();
        ppVol.profile.TryGetSettings(out depthLayer);  
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
    //Current goal: lerp blur focus distance per menu

    private void ToGameModeSelect()
    {
        //blur focus dist should be 6.92
        currentMenu = MenuType.GameModeSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
       // Instantiate();
        gameModeSelectMenu.SetActive(true);
        levelSelectMenu.SetActive(false);
        characterSelectMenu.SetActive(false);       
        StartCoroutine("ChangeDofDistance", 6.92f);

    }

    private void ToLevelSelect()
    {
        //blur focus dist should be 1.89
        currentMenu = MenuType.LevelSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
        gameModeSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
        characterSelectMenu.SetActive(false);       
        StartCoroutine("ChangeDofDistance", 1.89f);
    }

    private void ToCharacterSelect()
    {
        //blur focus dist should be 3.02
        Debug.Log("testingCharSel");
        currentMenu = MenuType.CharacterSelect;
        cameraAnimator.SetInteger("MenuType", (int) currentMenu);
        gameModeSelectMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        characterSelectMenu.SetActive(true);
        StartCoroutine("ChangeDofDistance", 3.02f);
    }
    IEnumerator ChangeDofDistance(float distVal)
    {
        float curVal = depthLayer.focusDistance.value;
        Debug.Log("distVal is " + distVal);
        if (curVal < distVal)
        {
            //increment i to get UP to distVal
            for (float i = curVal; i<distVal; i += .075f)
            {
                depthLayer.focusDistance.value = i;
                yield return null;
            }

        }
        else if (curVal > distVal)
        {
            //decrement i to get DOWN to distVal
            for (float i = curVal; i > distVal; i -= .075f)
            {
                depthLayer.focusDistance.value = i;
                yield return null;
            }

        }
        else
        {
            //theyre the same.
            //do nothing.
            yield return null;
        }

    }
}
