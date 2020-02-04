using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GoalLimitSlider : HorizontalSlider
{
    public int maxGoals = 99;

    protected override void Increment(InputValue inputValue)
    {
        if (++GameModeSelect.goalLimit > maxGoals)
            GameModeSelect.goalLimit = 0;
    }

    protected override void Decrement(InputValue inputValue)
    {
        if (--GameModeSelect.goalLimit < 0)
            GameModeSelect.goalLimit = maxGoals;
    }

    private void Update()
    {
        transform.GetChild(1).GetComponent<Text>().text = GameModeSelect.goalLimit.ToString();
        if (GameModeSelect.goalLimit == 0)
        {
            transform.GetChild(1).GetComponent<Text>().text = "No Limit";
        }
    }
}
