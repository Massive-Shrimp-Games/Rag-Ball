using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.InputSystem;

public class Menu_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Controller controller; 

    public int playerNumber; 
    
    

    void Start()
    {
        controller = Game.Instance.Controllers.GetController(playerNumber);
        controller.GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        Debug.Log(controller.GetComponent<PlayerInput>().currentActionMap);  
        if (controller != null)
        {
            controller._OnStartMenu += StartMenu; 
        }
    }

    private void OnDestroy()
    {
        if (controller != null)
        {
            controller._OnStartMenu -= StartMenu; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void StartMenu(InputValue inputValue){
        Debug.Log("HI");
        SceneManager.LoadScene("LevelSelect");
    }

    //Parent Menu Class
    //Move the Start Scene info to the new im
    //Cursor that uses graph to seek options, selects them

}
