using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCursor : MonoBehaviour
{
	public int playerNumber = 0;
	private Controller controller;
	public Selectable currentSelectable;

	private void Start(){
        if (Game.Instance == null)
        {
            return;
        }
		controller = Game.Instance.Controllers.GetController(playerNumber);
		controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
		MapControls();
	}

    public void setSelectable(Selectable s){
        currentSelectable = s; 
    }

    public void setPlayerNumber(int newNum){
        playerNumber = newNum; 
        UnmapControls(); 
        controller = Game.Instance.Controllers.GetController(playerNumber);
		controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        MapControls(); 
    }

	private void MapControls(){
		if (controller != null)
        {
            controller._OnProgressInMenu += ProgressInMenu;
        }
	}

    private void OnDestroy() {
        UnmapControls(); 
    }

    private void UnmapControls(){
		if (controller != null)
        {
            controller._OnProgressInMenu -= ProgressInMenu;
        }
	}

	protected void ProgressInMenu(InputValue inputValue){
        Vector2 move = inputValue.Get<Vector2>(); 
        if(move.x > .5f){
            //Right
            Debug.Log("Right"); 
            currentSelectable = currentSelectable.GetRight(); 
        }
        else if(move.x < -.5f){
            //Left
            Debug.Log("Left"); 
            currentSelectable = currentSelectable.GetLeft(); 
        }
        else if(move.y > .5f){
            //Up
            Debug.Log("Up"); 
            currentSelectable = currentSelectable.GetUp(); 
        }
        else if(move.y < -.5f){
            //Down
            Debug.Log("Down"); 
            currentSelectable = currentSelectable.GetDown(); 
        }
        this.gameObject.transform.position = currentSelectable.GetComponent<RectTransform>().position;  
    }
}
