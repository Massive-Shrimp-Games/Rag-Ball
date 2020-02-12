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

    protected override void OnReturn(InputValue inputValue)
    {
        if (active)
        {
            SceneManager.LoadScene("LevelSelect");
        } else
        {
            active = true;
        }
    }

    protected override void OnStart(InputValue inputValue)
    {
        SceneManager.LoadScene("Main_Game3");
    }

    private void SetImage()
    {
        GetComponent<Image>().sprite = cursorSprites[playerNumber];
    }
}
