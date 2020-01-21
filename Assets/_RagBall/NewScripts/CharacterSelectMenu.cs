using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : Menu
{
    public GameObject cursorPrefab;
    private List<PlayerCursor> playerCursors;

    public void Start(){
    	for (int i = 0; i < Game.Instance.Controllers.Count(); i++){
    		playerCursors.Add(new PlayerCursor(i));
    	}
    }

    override protected void StartMenu(InputValue inputValue){
        SceneManager.LoadScene("Main_Game");
    }

    override protected void BackToPreviousMenu(InputValue inputValue){
        SceneManager.LoadScene("LevelSelect");
    }
}
