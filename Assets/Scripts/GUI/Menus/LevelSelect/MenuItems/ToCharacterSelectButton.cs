
using UnityEngine.SceneManagement;
using UnityEngine;

public class ToCharacterSelectButton : Button
{
    public override void Select(PlayerCursor cursor)
    {
        
        MenuActions.ToCharacterSelect();
    }
    public override Vector3 localScale() {
        return new Vector3(5f, 9f, 5f);
    }
}
