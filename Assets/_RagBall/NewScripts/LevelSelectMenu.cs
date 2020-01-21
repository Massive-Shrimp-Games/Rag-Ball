using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class LevelSelectMenu : Menu
{

    // Start is called before the first frame update

    void Start()
    { 
        base.MapControls();
        //createGraph(); 
    }

    private void OnDestroy()
    {
        base.UnmapControls();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //protected override void createGraph(){
        /*
        //Button 0
        selectables[0].GetComponent<Selectable>().right = selectables[1].GetComponent<Selectable>(); 
        selectables[0].GetComponent<Selectable>().down = selectables[4].GetComponent<Selectable>();
        //Button 1
        selectables[1].GetComponent<Selectable>().left = selectables[0].GetComponent<Selectable>();
        selectables[1].GetComponent<Selectable>().right = selectables[2].GetComponent<Selectable>();
        selectables[1].GetComponent<Selectable>().down = selectables[5].GetComponent<Selectable>();
        //Button 2 
        selectables[2].GetComponent<Selectable>().left = selectables[1].GetComponent<Selectable>();
        selectables[2].GetComponent<Selectable>().down = selectables[3].GetComponent<Selectable>();
        //Button 3 
        selectables[3].GetComponent<Selectable>().up = selectables[2].GetComponent<Selectable>();
        selectables[3].GetComponent<Selectable>().down = selectables[7].GetComponent<Selectable>();
        //Button 4
        selectables[4].GetComponent<Selectable>().up = selectables[0].GetComponent<Selectable>();
        selectables[4].GetComponent<Selectable>().right = selectables[5].GetComponent<Selectable>();
        selectables[4].GetComponent<Selectable>().down = selectables[9].GetComponent<Selectable>();
        //Button 5
        selectables[5].GetComponent<Selectable>().up = selectables[1].GetComponent<Selectable>();
        selectables[5].GetComponent<Selectable>().right = selectables[6].GetComponent<Selectable>();
        selectables[5].GetComponent<Selectable>().left = selectables[4].GetComponent<Selectable>();
        selectables[5].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 6
        selectables[6].GetComponent<Selectable>().up = selectables[3].GetComponent<Selectable>();
        selectables[6].GetComponent<Selectable>().right = selectables[7].GetComponent<Selectable>();
        selectables[6].GetComponent<Selectable>().left = selectables[5].GetComponent<Selectable>();
        selectables[6].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 7
        selectables[7].GetComponent<Selectable>().up = selectables[3].GetComponent<Selectable>();
        selectables[7].GetComponent<Selectable>().right = selectables[4].GetComponent<Selectable>();
        selectables[7].GetComponent<Selectable>().left = selectables[6].GetComponent<Selectable>();
        selectables[7].GetComponent<Selectable>().down = selectables[11].GetComponent<Selectable>();
        //Button 8
        selectables[8].GetComponent<Selectable>().up = selectables[4].GetComponent<Selectable>();
        selectables[8].GetComponent<Selectable>().right = selectables[9].GetComponent<Selectable>();
        //selectables[8].GetComponent<Selectable>().left = selectables[5].GetComponent<Selectable>();
        //selectables[8].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 9
        selectables[9].GetComponent<Selectable>().up = selectables[4].GetComponent<Selectable>();
        selectables[9].GetComponent<Selectable>().right = selectables[10].GetComponent<Selectable>();
        selectables[9].GetComponent<Selectable>().left = selectables[8].GetComponent<Selectable>();
        //selectables[9].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 10
        selectables[10].GetComponent<Selectable>().up = selectables[6].GetComponent<Selectable>();
        selectables[10].GetComponent<Selectable>().right = selectables[9].GetComponent<Selectable>();
        selectables[10].GetComponent<Selectable>().left = selectables[11].GetComponent<Selectable>();
        //selectables[10].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 11
        selectables[11].GetComponent<Selectable>().up = selectables[7].GetComponent<Selectable>();
        selectables[11].GetComponent<Selectable>().right = selectables[12].GetComponent<Selectable>();
        selectables[11].GetComponent<Selectable>().left = selectables[10].GetComponent<Selectable>();
        //selectables[11].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        //Button 12
        selectables[12].GetComponent<Selectable>().up = selectables[7].GetComponent<Selectable>();
        selectables[12].GetComponent<Selectable>().right = selectables[8].GetComponent<Selectable>();
        selectables[12].GetComponent<Selectable>().left = selectables[11].GetComponent<Selectable>();
        //selectables[12].GetComponent<Selectable>().down = selectables[10].GetComponent<Selectable>();
        */
    //}

}
