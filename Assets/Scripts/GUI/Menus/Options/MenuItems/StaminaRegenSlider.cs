using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StaminaRegenSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        OptionsMenu.staminaRegenRate+=0.5f;
    }

    protected override void Decrement(InputValue inputValue)
    {
        OptionsMenu.staminaRegenRate-=0.5f;
    }

    private void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = OptionsMenu.staminaRegenRate.ToString();
    }
}
