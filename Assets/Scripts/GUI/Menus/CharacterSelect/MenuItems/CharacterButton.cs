public class CharacterButton : Button
{
    public TeamColor color;
    public RagdollSize size;

    public override void Select(PlayerCursor cursor)
    {
        CharacterSelect.playerSelections[cursor.playerNumber].color = color;
        CharacterSelect.playerSelections[cursor.playerNumber].size = size;
        cursor.hasControl = false;
    }
}
