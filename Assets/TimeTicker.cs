using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class TimeTicker : MonoBehaviour
{
    private int tick;
    private float timer;
    public static event EventHandler<OnTickEventArgs> OnTick;

    private IEnumerator StartCountdown(float countdownValue = 1)
    {
        float currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            //Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(0.85f);
            currCountdownValue--;
        }
    }

    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }
    void Awake()
    {
        tick = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OnTick != null)
        {
            StartCoroutine(StartCountdown());
            OnTick(this, new OnTickEventArgs { tick = tick });
            //yield return new WaitForSeconds(0.2f);

        }

    }
    private void OnDestroy()
    {
        OnTick = null;
    }

}
