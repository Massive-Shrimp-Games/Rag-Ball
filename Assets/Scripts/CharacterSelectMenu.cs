using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CharacterSelectMenu : Menu
{
    public List<GameObject> cursorPrefabs;
    private List<PlayerCursor> playerCursors;

    override protected void MapControls() {
        currentSelectable = currentSelectableObject.GetComponent<Selectable>();
        int s = Game.Instance.Controllers.Count();
    	for (int i = 0; i < s; i++){
            GameObject newCursor = Instantiate(cursorPrefabs[i], new Vector3(0,0,0), Quaternion.identity);
            newCursor.transform.parent = transform;
            newCursor.GetComponent<PlayerCursor>().playerNumber = i;
            newCursor.GetComponent<PlayerCursor>().setSelectable(currentSelectable);
            newCursor.transform.position = currentSelectable.transform.position;
    	}
    }

    override protected void StartMenu(InputValue inputValue){
        SceneManager.LoadScene("Main_Game");
    }

    override protected void BackToPreviousMenu(InputValue inputValue){
        SceneManager.LoadScene("LevelSelect");
    }
}
