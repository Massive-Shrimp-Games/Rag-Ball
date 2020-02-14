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

    public GameObject TieLeftLeftPosition;
    public GameObject TieLeftMiddlePosition;
    public GameObject TieRightMiddlePosition;
    public GameObject TieRightRightPosition;

    public List<GameObject> RedList = new List<GameObject>();
    public List<GameObject> BlueList = new List<GameObject>();

    public void Start()
    {
        RedWinText.SetActive(false);
        BlueWinText.SetActive(false);
        TieWinText.SetActive(false);
    }



    public void DisplayWinner()
    {
        RedList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().RedTeamHips;
        BlueList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().BlueTeamHips;

        ActionMapEvent.InMenu?.Invoke();
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
        /*if (RagballRuleset.blueScore == RagballRuleset.redScore && RagballRuleset.blueScore == GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            TieWinText.SetActive(true);
            TieWin();
        }*/
        if (RagballRuleset.redScore == RagballRuleset.blueScore)
        {
            TieWinText.SetActive(true);
            TieWin();
        }
    }

    private void RedWin()
    {
        RedList[0].transform.position = WinLeftPosition.transform.position;
        RedList[1].transform.position = WinRightPosition.transform.position;

        BlueList[0].transform.position = LoseLeftPosition.transform.position;
        BlueList[1].transform.position = LoseRightPosition.transform.position;
    }

    private void BlueWin()
    {
        BlueList[0].transform.position = WinLeftPosition.transform.position;
        BlueList[1].transform.position = WinRightPosition.transform.position;

        RedList[0].transform.position = LoseLeftPosition.transform.position;
        RedList[1].transform.position = LoseRightPosition.transform.position;
    }

    private void TieWin()
    {
        BlueList[0].transform.position = TieRightMiddlePosition.transform.position;
        BlueList[1].transform.position = TieRightRightPosition.transform.position;

        RedList[0].transform.position = TieLeftLeftPosition.transform.position;
        RedList[1].transform.position = TieLeftMiddlePosition.transform.position;
    }


}
