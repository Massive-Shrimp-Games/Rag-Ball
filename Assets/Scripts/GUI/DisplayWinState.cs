using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinState : MonoBehaviour
{
    public GameObject RedWinText;
    public GameObject BlueWinText;
    public GameObject TieWinText;
    public GameObject WinLeftPosition;
    public GameObject WinRightPosition;
    public GameObject LoseLeftPosition;
    public GameObject LoseRightPosition;

    

    public void Start()
    {
        RedWinText.SetActive(false);
        BlueWinText.SetActive(false);
        TieWinText.SetActive(false);
    }

    public void DisplayWinner()
    {
        GameObject.Find("Stamina_Canvas").SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0.55f, 4.62f, 1.19f);
        GameObject.Find("Main Camera").transform.Rotate(-18.372f, 0f, 0f);
        if (RagballRuleset.redScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            RedWinText.SetActive(true);
            RedWin();
        }
        if (RagballRuleset.blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueWinText.SetActive(true);
            BlueWin();
        }
        if (RagballRuleset.blueScore == RagballRuleset.redScore && RagballRuleset.blueScore == GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            TieWinText.SetActive(true);
            TieWin();
        }
    }

    private void RedWin()
    {
        
    }

    private void BlueWin()
    {

    }

    private void TieWin()
    {

    }


}
