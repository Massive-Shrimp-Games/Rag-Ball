using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectCursor : PlayerCursor
{
    public List<Sprite> cursorSprites;

    protected override void Start()
    {
        base.Start();
        SetImage();
    }

    protected override void OnConfirm(InputValue inputValue)
    {
        base.OnConfirm(inputValue);
        CharacterSelect.playerSelectionEvent?.Invoke(this);
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
        }
    }

    protected override void OnStart(InputValue inputValue)
    {
        SceneManager.LoadScene("Court");
    }

    private void SetImage()
    {
        GetComponent<Image>().sprite = cursorSprites[playerNumber];
    }
}
