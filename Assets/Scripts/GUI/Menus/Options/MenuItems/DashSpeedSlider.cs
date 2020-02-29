using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DashSpeedSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        OptionsMenu.dashSpeed+=500;
    }

    protected override void Decrement(InputValue inputValue)
    {
        OptionsMenu.dashSpeed-=500;
    }

    private void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = OptionsMenu.dashSpeed.ToString();
    }
}
