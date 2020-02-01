using System.Collections.Generic;
using UnityEngine;

public class RandomCharacterButton : Button
{
    public List<Button> buttons;
    public override void Select(PlayerCursor cursor)
    {
        int randomButton = Random.Range(0, buttons.Count - 1);
        buttons[randomButton].Select(cursor);
    }
}
