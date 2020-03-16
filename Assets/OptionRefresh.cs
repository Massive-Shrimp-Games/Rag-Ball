using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionRefresh : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Button option1;
    [SerializeField] private Button option2;
    [SerializeField] private Button option3;
    private void OnEnable() {
        option1.updateDisplay();
        option2.updateDisplay();
        option3.updateDisplay();
    }
}
