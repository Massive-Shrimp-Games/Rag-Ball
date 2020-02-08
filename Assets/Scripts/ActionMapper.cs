using UnityEngine;
using UnityEngine.InputSystem;

public class ActionMapper : MonoBehaviour
{
    private void Start()
    {
        ActionMapEvent.InMenu += LoadMenuMap;
        ActionMapEvent.InGameplay += LoadGameplayMap;
    }

    private void OnDestroy()
    {
        ActionMapEvent.InMenu -= LoadMenuMap;
        ActionMapEvent.InGameplay -= LoadGameplayMap;
    }

    private void LoadMenuMap()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            Game.Instance.Controllers.GetController(i)
                .GetComponent<PlayerInput>().SwitchCurrentActionMap("Menu");
        }
    }

    private void LoadGameplayMap()
    {
        if (Game.Instance == null) return;
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++)
        {
            Game.Instance.Controllers.GetController(i)
                .GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
        }
    }
}
