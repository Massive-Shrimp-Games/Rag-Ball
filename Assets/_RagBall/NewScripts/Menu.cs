using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public abstract class Menu : MonoBehaviour
{   
    protected Controller controller; 

    public int playerNumber;

    public Image cursor; 

    protected Selectable currentSelectable;

    public GameObject currentSelectableObject;

    public List<Selectable> selectables;  


    // Start is called before the first frame update
    void Start()
    {
        if (Game.Instance == null) return;
        MapControls(); 
        BindInputs();
    }

    virtual protected void MapControls() {
        controller = Game.Instance.Controllers.GetController(playerNumber);
        controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        Debug.Log(controller.GetComponent<PlayerInput>().currentActionMap);  
        currentSelectable = selectables[0]; 
        cursor.rectTransform.position = currentSelectable.image.GetComponent<RectTransform>().position;
    }

    private void BindInputs() {
        if (controller != null)
        {
            controller._OnStartMenu += StartMenu; 
            controller._OnProgressInMenu += ProgressInMenu;
            controller._OnRegressInMenu += RegressInMenu;
            controller._OnBackToPreviousMenu += BackToPreviousMenu;
        }
    }

    private void OnDestroy()
    {
        UnmapControls(); 
    }

    protected void UnmapControls(){
        if (controller != null)
        {
            controller._OnStartMenu -= StartMenu;
            controller._OnProgressInMenu -= ProgressInMenu;
            controller._OnRegressInMenu -= RegressInMenu; 
            controller._OnBackToPreviousMenu -= BackToPreviousMenu; 
        }
    }

    virtual protected void StartMenu(InputValue inputValue){
        Debug.Log("Hi"); 
        SceneManager.LoadScene("CharacterSelect");
    }

    protected void ProgressInMenu(InputValue inputValue){
        Debug.Log("Pro"); 
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
        cursor.rectTransform.position = currentSelectable.GetComponent<RectTransform>().position; 
        Debug.Log(currentSelectable.name);
        //Debug.Log(currentSelectable.left.name + " " + currentSelectable.up.name + " " + currentSelectable.right.name + " " + currentSelectable.down.name + " " );
        //Move image cursor to next button position
        //cursor.rectTransform = selectableObjects[buttonCounter].GetComponent<RectTransform>(); 
        //selectableObjects[buttonCounter]; 
    }


    protected void RegressInMenu(InputValue inputValue){
        Debug.Log("Reg"); 
    }

    virtual protected void BackToPreviousMenu(InputValue inputValue){
        SceneManager.LoadScene("StartScreen");
    }

    //protected abstract void createGraph();
}
