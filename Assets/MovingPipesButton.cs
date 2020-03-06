using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingPipesButton : Button
{
    // Start is called before the first frame update
    public Image checkBox;
    public bool isChecked = false;
    [SerializeField] private Sprite turnedOff;
    [SerializeField] private Sprite turnedOn;

    public override void Select(PlayerCursor cursor)
    {
        //Set the static to the opposite of what it is
        LevelSelect.pipesMove = !LevelSelect.pipesMove;
        if(LevelSelect.pipesMove)
        {

        } else {

        }
    }
    public override void updateDisplay() {}
}
