using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class LevelSelectMenu : MonoBehaviour
{
    private Controller controller; 

    public int playerNumber;

    public List<Button> selectableObjects; 

    private int buttonCounter; 

    public Image cursor; 

    // Start is called before the first frame update
    void Start()
    {
        controller = Controllers.Instance.GetController(playerNumber);
        controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        Debug.Log(controller.GetComponent<PlayerInput>().currentActionMap);  
        if (controller != null)
        {
            controller._OnStartMenu += StartMenu; 
            controller._OnProgressInMenu += ProgressInMenu;
            controller._OnRegressInMenu += RegressInMenu;
        }
        selectableObjects[0].Select(); 
        buttonCounter = 0; 
    }
    private void OnDestroy()
    {
        if (controller != null)
        {
            controller._OnStartMenu -= StartMenu;
            controller._OnProgressInMenu -= ProgressInMenu;
            controller._OnRegressInMenu -= RegressInMenu; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartMenu(InputValue inputValue){
        Debug.Log("Hi"); 
        SceneManager.LoadScene("CharacterSelect");
    }

    void ProgressInMenu(InputValue inputValue){
        Debug.Log("Pro"); 
        Vector2 move = inputValue.Get<Vector2>(); 
        if(move.x > .5f){
            //Right
            Debug.Log("Right"); 
        }
        else if(move.x < -.5f){
            //Left
            Debug.Log("Left"); 
        }
        else if(move.y > .5f){
            //Up
            Debug.Log("Up"); 
        }
        else if(move.y < -.5f){
            //Down
            Debug.Log("Down"); 
        }
        buttonCounter++; 
        if (buttonCounter > selectableObjects.Count - 1){
            buttonCounter = 0; 
        }
        cursor.rectTransform.position = selectableObjects[buttonCounter].GetComponent<RectTransform>().position; 
        Debug.Log(selectableObjects[buttonCounter].GetComponent<RectTransform>().position);
        Debug.Log(selectableObjects[buttonCounter].gameObject.name);
        //Move image cursor to next button position
        //cursor.rectTransform = selectableObjects[buttonCounter].GetComponent<RectTransform>(); 
        //selectableObjects[buttonCounter]; 
    }

    void RegressInMenu(InputValue inputValue){
        Debug.Log("Reg"); 
        buttonCounter--; 
        if (buttonCounter < 0){
            buttonCounter = selectableObjects.Count - 1; 
        }
        cursor.rectTransform.position = selectableObjects[buttonCounter].GetComponent<RectTransform>().position;
        //selectableObjects[buttonCounter].Select();
    }
}
