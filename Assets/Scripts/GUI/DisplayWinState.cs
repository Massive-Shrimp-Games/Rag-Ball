using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinState : MonoBehaviour
{
    public GameObject RedWin;
    public GameObject BlueWin;
    public GameObject TieWin;

    public void Start()
    {
        RedWin.SetActive(false);
        BlueWin.SetActive(false);
        TieWin.SetActive(false);
    }

    public void DisplayWinner()
    {
        if (RagballRuleset.redScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            RedWin.SetActive(true);
        }
        if (RagballRuleset.blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueWin.SetActive(true);
        }
        if (RagballRuleset.blueScore == RagballRuleset.redScore && RagballRuleset.blueScore == GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            TieWin.SetActive(true);
        }
    }
}
