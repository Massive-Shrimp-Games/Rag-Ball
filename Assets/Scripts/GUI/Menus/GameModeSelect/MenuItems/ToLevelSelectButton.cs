using UnityEngine.SceneManagement;

public class ToLevelSelectButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
