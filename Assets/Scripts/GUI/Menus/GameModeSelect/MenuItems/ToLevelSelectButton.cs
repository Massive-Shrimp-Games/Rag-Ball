using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelSelectButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        if(GameModeSelect.gameMode == GameMode.Mode.RagOfTheHill)
        {
            SceneManager.LoadScene("RagOfTheHill");
            //MenuActions.ToCharacterSelect();
        } else {
            MenuActions.ToLevelSelect();
        }
    }
}
