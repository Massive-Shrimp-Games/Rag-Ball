using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlippyFloorsButton : Button
{
    // Start is called before the first frame update
    public Image checkBox;
    public bool isChecked = false;
    [SerializeField] private Sprite turnedOff;
    [SerializeField] private Sprite turnedOn;

    public override void Select(PlayerCursor cursor)
    {
        //Set the static to the opposite of what it is
        LevelSelect.slipperyFloor = !LevelSelect.slipperyFloor;
        updateDisplay();
    }
    public override void updateDisplay() {
        if(LevelSelect.slipperyFloor)
        {
            checkBox.sprite = turnedOn;
        } else {
            checkBox.sprite = turnedOff;
        }
    }
    public override Vector3 localScale() {
        return new Vector3(3f, 9f,3f);
    }
}
