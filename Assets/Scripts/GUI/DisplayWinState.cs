using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayWinState : MonoBehaviour
{
    public GameObject RedWinText;
    public GameObject BlueWinText;
    public GameObject TieWinText;
    public GameObject WinLeftDancer;
    public GameObject WinRightDancer;
    public GameObject LoseLeftPosition;
    public GameObject LoseRightPosition;

    public GameObject TieLeftLeftDancer;
    public GameObject TieLeftMidDancer;
    public GameObject TieRightMidDancer;
    public GameObject TieRightRightDancer;

    public List<Mesh> MeshSize = new List<Mesh>();
    public List<Material> PlayerMaterials = new List<Material>();

    private bool isWinState = false;
    private bool isTieState = false;

    //public List<GameObject> RedHipsList = new List<GameObject>();
    //public List<GameObject> BlueHipsList = new List<GameObject>();

    public List<GameObject> RedPlayerList = new List<GameObject>();
    public List<GameObject> BluePlayerList = new List<GameObject>();

    public GameObject RestartGameButton;
    public GameObject BacktoMenuButton;
    public GameObject Cursor;

    public void Start()
    {
        RedWinText.SetActive(false);
        BlueWinText.SetActive(false);
        TieWinText.SetActive(false);
        WinLeftDancer.SetActive(false);
        WinRightDancer.SetActive(false);
        LoseLeftPosition.SetActive(false);
        LoseRightPosition.SetActive(false);
        TieLeftLeftDancer.SetActive(false);
        TieLeftMidDancer.SetActive(false);
        TieRightMidDancer.SetActive(false);
        TieRightRightDancer.SetActive(false);

        RestartGameButton.SetActive(false);
        BacktoMenuButton.SetActive(false);
        Cursor.SetActive(false);
    }

    private void SetDancersActive()
    {
        if (isWinState == true)
        {
            WinLeftDancer.SetActive(true);
            WinRightDancer.SetActive(true);
            LoseLeftPosition.SetActive(true);
            LoseRightPosition.SetActive(true);
        }

        if (isTieState == true)
        {
            TieLeftLeftDancer.SetActive(true);
            TieLeftMidDancer.SetActive(true);
            TieRightMidDancer.SetActive(true);
            TieRightRightDancer.SetActive(true);
        }
    }

    public void DisplayWinner()
    {
        //RedHipsList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().RedTeamHips;
        //BlueHipsList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().BlueTeamHips;

        RedPlayerList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().RedTeam;
        BluePlayerList = GameObject.Find("Players").GetComponent<FindPlayerTeams>().BlueTeam;

        ActionMapEvent.InMenu?.Invoke();
        GameObject.Find("Stamina_Canvas").SetActive(false);
        GameObject.Find("Main Camera").transform.position = new Vector3(0.55f, 4.79f, 1.21f);
        GameObject.Find("Main Camera").transform.Rotate(-18.372f, 0f, 0f);
        if (RagballRuleset.redScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            RedWinText.SetActive(true);
            isWinState = true;
            SetDancersActive();
            RedWin();
        }
        if (RagballRuleset.blueScore >= GameModeSelect.goalLimit && GameModeSelect.goalLimit != 0)
        {
            BlueWinText.SetActive(true);
            isWinState = true;
            SetDancersActive();
            BlueWin();
        }
        if (RagballRuleset.redScore == RagballRuleset.blueScore)
        {
            TieWinText.SetActive(true);
            isTieState = true;
            SetDancersActive();
            TieWin();
        }
    }

    public void DisplayButtons()
    {
        RestartGameButton.SetActive(true);
        BacktoMenuButton.SetActive(true);
        Cursor.SetActive(true);
    }

    private void RedWin()
    {
        if (RedPlayerList.Count <= 0)
        {
            WinLeftDancer.SetActive(false);
        }

        else if (RedPlayerList[0])
        {
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[0]);
        }

        if (RedPlayerList.Count <= 1)
        {
            WinRightDancer.SetActive(false);
        }

        else if (RedPlayerList[1])
        {
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[1]);
        }

        if (BluePlayerList.Count <= 0)
        {
            LoseLeftPosition.SetActive(false);
        }

        else if (BluePlayerList[0])
        {
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[0]);
        }
        

        if (BluePlayerList.Count <= 1)
        {
            LoseRightPosition.SetActive(false);
        }

        else if (BluePlayerList[1])
        {
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[1]);
        }
    }

    private void BlueWin()
    {
        if (BluePlayerList.Count <= 0)
        {
            WinLeftDancer.SetActive(false);
        }

        else if (BluePlayerList[0])
        {
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                WinLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[0]);
        }


        if (BluePlayerList.Count <= 1)
        {
            WinRightDancer.SetActive(false);
        }

        else if (BluePlayerList[1])
        {
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                WinRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[1]);
        }


        if (RedPlayerList.Count <= 0)
        {
            LoseLeftPosition.SetActive(false);
        }

        else if (RedPlayerList[0])
        {
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                LoseLeftPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[0]);
        }

        if (RedPlayerList.Count <= 1)
        {
            LoseRightPosition.SetActive(false);
        }

        else if (RedPlayerList[1])
        {
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                LoseRightPosition.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[1]);
        }
    }

    private void TieWin()
    {
        if (RedPlayerList.Count <= 0)
        {
            TieLeftMidDancer.SetActive(false);
        }

        else if (RedPlayerList[0])
        {
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                TieLeftMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[0]);
        }
        
        if (RedPlayerList.Count <= 1)
        {
            TieLeftLeftDancer.SetActive(false);
        }

        else if (RedPlayerList[1])
        {
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[0];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[1];
            }
            if (RedPlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                TieLeftLeftDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[2];
            }

            Destroy(RedPlayerList[1]);
        }

        if (BluePlayerList.Count <= 0)
        {
            TieRightMidDancer.SetActive(false);
        }

        else if (BluePlayerList[0])
        {
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[0].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                TieRightMidDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[0]);
        }

        if (BluePlayerList.Count <= 1)
        {
            TieRightRightDancer.SetActive(false);
        }

        else if (BluePlayerList[1])
        {
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Large)
            {
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[0];
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[3];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Medium)
            {
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[1];
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[4];
            }
            if (BluePlayerList[1].transform.GetChild(0).GetComponent<Player>().size == RagdollSize.Small)
            {
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().sharedMesh = MeshSize[2];
                TieRightRightDancer.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>().material = PlayerMaterials[5];
            }

            Destroy(BluePlayerList[1]);
        }
    }
}
