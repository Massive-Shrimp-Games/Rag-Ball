using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameModeSlider : HorizontalSlider
{
    protected override void Increment(InputValue inputValue)
    {
        Debug.Log("Increment game mode");
        if ((int)++GameModeSelect.gameMode >= GameMode.Count)
        {
            GameModeSelect.gameMode = 0;
        }
    }

    protected override void Decrement(InputValue inputValue)
    {
        Debug.Log("Decrement game mode");
        if ((int)--GameModeSelect.gameMode < 0)
        {
            GameModeSelect.gameMode = (GameMode.Mode)GameMode.Count - 1;
        }
    }

    private void Update()
    {
        if (GameModeSelect.gameMode == GameMode.Mode.RagBall)
            transform.GetChild(1).GetComponent<Text>().text = "RagBall";
        else if (GameModeSelect.gameMode == GameMode.Mode.RagOfTheHill)
            transform.GetChild(1).GetComponent<Text>().text = "Rag of the Hill";
        else if (GameModeSelect.gameMode == GameMode.Mode.CaptureTheRag)
            transform.GetChild(1).GetComponent<Text>().text = "Capture the Rag";
        else
            transform.GetChild(1).GetComponent<Text>().text = "Unknown";
    }
}
