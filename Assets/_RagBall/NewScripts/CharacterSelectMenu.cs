using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : Menu
{
    public GameObject cursorPrefab;
    public void Start(){
        /*for (){
            PlayerInput playerInput = PlayerInput.Instantiate(cursorPrefab,
                playerIndex: playerIndex,
                pairWithDevice: inputDevice
                );
        }*/
    }

    override protected void StartMenu(InputValue inputValue){
        SceneManager.LoadScene("Main_Game");
    }

    override protected void BackToPreviousMenu(InputValue inputValue){
        SceneManager.LoadScene("LevelSelect");
    }
}
