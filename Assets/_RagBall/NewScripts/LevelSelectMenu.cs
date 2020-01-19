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
        selectableObjects[buttonCounter].Select();
        buttonCounter++; 
        selectableObjects[buttonCounter].Select();
    }

    void RegressInMenu(InputValue inputValue){
        
    }
}
