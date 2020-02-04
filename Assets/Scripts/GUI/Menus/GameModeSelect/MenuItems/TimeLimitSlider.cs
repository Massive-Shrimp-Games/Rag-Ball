using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TimeLimitSlider : HorizontalSlider
{
    public int maxTimeLimit = 99;
    protected override void Increment(InputValue inputValue)
    {
        if (++GameModeSelect.timeLimit > maxTimeLimit)
            GameModeSelect.timeLimit = 0;
    }

    protected override void Decrement(InputValue inputValue)
    {
        if (--GameModeSelect.timeLimit < 0)
            GameModeSelect.timeLimit = maxTimeLimit;
    }

    private void Update()
    {
        transform.GetChild(1).GetComponent<Text>().text = GameModeSelect.timeLimit.ToString();
        if (GameModeSelect.timeLimit == 0)
        {
            transform.GetChild(1).GetComponent<Text>().text = "No Limit";
        }
    }
}
