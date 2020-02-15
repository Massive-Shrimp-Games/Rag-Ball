using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ROTHManager : MonoBehaviour
{
    public int P1Score;
    public text P1Text;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1Text.text = P1Score.ToString();
    }
}
