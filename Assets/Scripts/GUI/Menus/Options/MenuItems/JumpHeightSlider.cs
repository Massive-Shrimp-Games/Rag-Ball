using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JumpHeightSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        OptionsMenu.jumpHeight+=1000;
    }

    protected override void Decrement(InputValue inputValue)
    {
        OptionsMenu.jumpHeight-=1000;
    }

    private void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = OptionsMenu.jumpHeight.ToString();
    }
}
