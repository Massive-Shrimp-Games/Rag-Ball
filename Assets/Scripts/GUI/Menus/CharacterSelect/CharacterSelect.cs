using System.Collections.Generic;

public static class CharacterSelect
{
    public static CharacterSelection[] playerSelections = new CharacterSelection[4]
    {
        new CharacterSelection(TeamColor.Red, RagdollSize.Medium),
        new CharacterSelection(TeamColor.Blue, RagdollSize.Medium),
        new CharacterSelection(TeamColor.Red, RagdollSize.Large),
        new CharacterSelection(TeamColor.Blue, RagdollSize.Large)
    };

    public delegate void SelectEvent(CharacterSelectCursor cursor);
    public static SelectEvent playerSelectionEvent;
}
