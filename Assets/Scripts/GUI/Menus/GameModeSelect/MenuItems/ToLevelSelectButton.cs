using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelSelectButton : Button
{
    public Animator cameraAnimator;

    public override void Select(PlayerCursor cursor)
    {
        cameraAnimator.SetFloat("CamAnimate", 0.5f);
    }
}
