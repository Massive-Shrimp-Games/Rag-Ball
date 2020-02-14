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

    public List<GameObject> RedHipsList = new List<GameObject>();
    public List<GameObject> BlueHipsList = new List<GameObject>();

    public List<GameObject> RedPlayerList = new List<GameObject>();
    public List<GameObject> BluePlayerList = new List<GameObject>();

    public void Start()
    {
        RedWinText.SetActive(false);
        BlueWinText.SetActive(false);
        TieWinText.SetActive(false);
    }



    public void DisplayWinner()
    {
        RedHipsList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().RedTeamHips;
        BlueHipsList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().BlueTeamHips;

        RedPlayerList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().RedTeam;
        BluePlayerList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().BlueTeam;

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
        RedHipsList[0].transform.position = WinLeftPosition.transform.position;
        RedHipsList[1].transform.position = WinRightPosition.transform.position;
        RedHipsList[0].transform.rotation = WinLeftPosition.transform.rotation;
        RedHipsList[1].transform.rotation = WinRightPosition.transform.rotation;

        BlueHipsList[0].transform.position = LoseLeftPosition.transform.position;
        BlueHipsList[1].transform.position = LoseRightPosition.transform.position;
        BlueHipsList[0].transform.rotation = LoseLeftPosition.transform.rotation;
        BlueHipsList[1].transform.rotation = LoseRightPosition.transform.rotation;
    }

    private void BlueWin()
    {
        BlueHipsList[0].transform.position = WinLeftPosition.transform.position;
        BlueHipsList[1].transform.position = WinRightPosition.transform.position;
        BlueHipsList[0].transform.rotation = WinLeftPosition.transform.rotation;
        BlueHipsList[1].transform.rotation = WinRightPosition.transform.rotation;

        RedHipsList[0].transform.position = LoseLeftPosition.transform.position;
        RedHipsList[1].transform.position = LoseRightPosition.transform.position;
        RedHipsList[0].transform.rotation = LoseLeftPosition.transform.rotation;
        RedHipsList[1].transform.rotation = LoseRightPosition.transform.rotation;
    }

    private void TieWin()
    {
        BlueHipsList[0].transform.position = TieRightMiddlePosition.transform.position;
        BlueHipsList[1].transform.position = TieRightRightPosition.transform.position;
        BlueHipsList[0].transform.rotation = TieRightMiddlePosition.transform.rotation;
        BlueHipsList[1].transform.rotation = TieRightRightPosition.transform.rotation;

        RedHipsList[0].transform.rotation = TieLeftLeftPosition.transform.rotation;
        RedHipsList[1].transform.rotation = TieLeftMiddlePosition.transform.rotation;
        RedHipsList[0].transform.position = TieLeftLeftPosition.transform.position;
        RedHipsList[1].transform.position = TieLeftMiddlePosition.transform.position;
    }


}
