using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        if ((int)++LevelSelect.level >= GameLevel.Count)
        {
            LevelSelect.level = 0;
        }
    }

    protected override void Decrement(InputValue inputValue)
    {
        if ((int)--LevelSelect.level < 0)
        {
            LevelSelect.level = (GameLevel.Level)GameLevel.Count - 1;
        }
    }

    private void Update()
    {
        if (LevelSelect.level == GameLevel.Level.Court1)
            transform.GetChild(1).GetComponent<Text>().text = "Court 1";
        else if (LevelSelect.level == GameLevel.Level.Court2)
            transform.GetChild(1).GetComponent<Text>().text = "Court 2";
    }
    public override Vector3 localScale() {
        return new Vector3(7.850089f, 7.850089f, 7.850089f);
    }
}
