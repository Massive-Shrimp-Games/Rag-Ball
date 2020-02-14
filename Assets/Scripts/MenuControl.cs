using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public Animator camAnimator;
   
    public float currentMenu = 0;
    float newMenuFloat;
    //MenuControl is the script that loads and unloads the different menus and activates the transitions between the different camera positions.
   
    void Start()
    {
        currentMenu = camAnimator.GetFloat("CamAnimate");
        // SceneManager.LoadScene("GameModeSelect", LoadSceneMode.Additive);
    }

    //The code commented out in update lets the user test the camera animations / menu loading with keyboard commands. 
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            //Advance by 1 menu if possible.
            if (currentMenu >= 1)
            {
                //Cant Progress, do nothing.
                Debug.Log("You're out of menus to go to dummy");
            }
            else
            {
                currentMenu += (float)0.5;
                camAnimator.SetFloat("CamAnimate", currentMenu);
            }
            Load();
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //Go back by 1 menu if possible.
            if (currentMenu <= 0)
            {
                //Cant Progress, do nothing.
                Debug.Log("You're out of menus to go to dummy");
            }
            else
            {
                currentMenu -= (float)0.5;
                camAnimator.SetFloat("CamAnimate", currentMenu);
            }
            Load();
        } */
        
        
    }

    public void Load()
    {
        //Function that operates both camera animation and additive scene loading.    
        //Unloads previous menu, loads new menu, plays matching animation to move camera into position.
        //0 is menu1(characters), .5 is menu2(Gamemode), 1 is menu3(options).

        float menuPick = currentMenu;
        //Debug.Log("menu number in load function is: " + (menuPick));
        switch (menuPick)
        {
            
            case 0:
                //char menu 
                //Don't need to check if scene 2 is loaded, since there is no case where someone would be switching TO character menu without being on Gamemode menu. 
                SceneManager.UnloadSceneAsync(2);
                SceneManager.LoadScene(1, LoadSceneMode.Additive);
                camAnimator.SetFloat("CamAnimate", currentMenu);
              
                break;
            case (float)0.5:
                //gamemode
                //Checks which scene needs to be unloaded. 
                if(SceneManager.GetSceneByBuildIndex(1).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(1);
                }
                if (SceneManager.GetSceneByBuildIndex(3).isLoaded)
                {
                    SceneManager.UnloadSceneAsync(3);
                }              
                SceneManager.LoadScene(2, LoadSceneMode.Additive);
                camAnimator.SetFloat("CamAnimate", currentMenu);
                
                break;
            case 1:
                //options
                //Same deal as case 0.
                SceneManager.UnloadSceneAsync(2);
                SceneManager.LoadScene(3, LoadSceneMode.Additive);
                camAnimator.SetFloat("CamAnimate", currentMenu);
                
                break;
        }
        
        
    }
    
}
