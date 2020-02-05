using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshPro clockText;
    public float timer;

    void Start()
    {
        timer = GameModeSelect.timeLimit;
        clockText.text = timer.ToString("F");
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        clockText.text = timer.ToString("F");
    

        if( timer <= 0f)
        {
            timer = 0f;
            clockText.text = timer.ToString("F");
        }

    }
}
