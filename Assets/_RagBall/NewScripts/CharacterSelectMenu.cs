using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : Menu
{
    public List<GameObject> cursorPrefabs;
    private List<PlayerCursor> playerCursors;

    public void Start(){
        if (Game.Instance == null) return; 
        int s = Game.Instance.Controllers.Count();
        Debug.Log(s); 
    	for (int i = 0; i < s; i++){
            GameObject newCursor = Instantiate(cursorPrefabs[i], new Vector3(0,0,0), Quaternion.identity); 
            newCursor.transform.parent = transform; 
            playerCursors.Add(newCursor.GetComponent<PlayerCursor>()); 
            playerCursors[i].setSelectable(currentSelectable); 
    	}
    }

    override protected void StartMenu(InputValue inputValue){
        SceneManager.LoadScene("Main_Game");
    }

    override protected void BackToPreviousMenu(InputValue inputValue){
        SceneManager.LoadScene("LevelSelect");
    }
}
