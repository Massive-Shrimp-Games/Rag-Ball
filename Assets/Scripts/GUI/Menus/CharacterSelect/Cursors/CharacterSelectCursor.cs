using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectCursor : PlayerCursor
{
    public List<Sprite> cursorSprites;
    public bool letsGo = false;

    protected override void Start()
    {
        base.Start();
        SetImage();
    }

    protected override void OnConfirm(InputValue inputValue)
    {
        if (letsGo)
        {
            if (GameModeSelect.gameMode == GameMode.Mode.RagOfTheHill)
            {
                SceneManager.LoadScene("RagOfTheHill");
            }
            else
            {
                SceneManager.LoadScene("Court");
            }
        }
        else
        {
            base.OnConfirm(inputValue);
            CharacterSelect.playerSelectionEvent?.Invoke(this);
            GetComponent<Image>().color = Color.magenta;
        }
    }

    protected override void OnReturn(InputValue inputValue)
    {
        if (hasControl)
        {
            MenuActions.ToLevelSelect();
        }
        else
        {
            hasControl = true;
            CharacterSelect.playerSelectionEvent?.Invoke(this);
            GetComponent<Image>().color = Color.white;

        }
    }

    protected override void OnStart(InputValue inputValue) { }

    private void SetImage()
    {
        GetComponent<Image>().sprite = cursorSprites[playerNumber];
    }
}
