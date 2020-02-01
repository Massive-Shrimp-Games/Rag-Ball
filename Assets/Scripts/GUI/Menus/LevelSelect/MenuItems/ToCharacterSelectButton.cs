using UnityEngine.SceneManagement;

public class ToCharacterSelectButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        SceneManager.LoadScene("CharacterSelect");
    }
}
