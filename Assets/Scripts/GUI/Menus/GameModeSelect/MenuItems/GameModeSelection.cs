using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModeSelection : MonoBehaviour
{
    private void Update()
    {
        if (GameModeSelect.gameMode == GameMode.Mode.RagBall)
            GetComponent<Text>().text = "RagBall";
        else if (GameModeSelect.gameMode == GameMode.Mode.RagOfTheHill)
            GetComponent<Text>().text = "Rag of the Hill";
        else if (GameModeSelect.gameMode == GameMode.Mode.LazerRag)
            GetComponent<Text>().text = "Lazer Rag";
        else
            GetComponent<Text>().text = "Unknown";
    }
}
