using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class StaggerDurationSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        OptionsMenu.staggerDuration++;
    }

    protected override void Decrement(InputValue inputValue)
    {
        OptionsMenu.staggerDuration--;
    }

    private void Update()
    {
        transform.GetChild(0).GetComponent<Text>().text = OptionsMenu.staggerDuration.ToString();
    }
}
