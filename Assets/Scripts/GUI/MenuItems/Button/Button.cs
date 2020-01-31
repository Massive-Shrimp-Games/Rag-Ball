using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectButton : Button
{
    public TeamColor color;
    public RagdollType type;

    public override void Select(Cursor cursor)
    {
        CharacterInfoWrapper ciw = new CharacterInfoWrapper();
        ciw.color = color;
        ciw.type = type;
        CharacterSelect.playerSelections[cursor.playerNumber] = ciw;
        Debug.LogFormat("CHARACTER SELECTED: Player {0} chose {1}, {2}", cursor.playerNumber, ciw.color, ciw.type);
    }
}
