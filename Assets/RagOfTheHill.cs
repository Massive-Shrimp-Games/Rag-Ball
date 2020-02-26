using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagOfTheHill : MonoBehaviour
{
    public GameObject GameManager;

    public float P1timer;
    public float P2timer;
    public float P3timer;
    public float P4timer;

    public int pointValue;

    private float originalTimer;
    // Start is called before the first frame update
    void Start()
    {
         originalTimer = P1timer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            

            if (other.GetComponent<BaseObject>().player.playerNumber == 1)
            {

                if (P1timer >= 0.0f)
                {
                    P1timer -= Time.deltaTime;
                    int min = Mathf.FloorToInt(P1timer / 60);
                    int sec = Mathf.FloorToInt(P1timer % 60);
                    
                }
                if (P1timer <= 0.0f)
                {
                    P1timer = originalTimer;
                    GameManager.GetComponent<ROTHManager>().P1AddScore(pointValue);
                }           
                  
             }

            if (other.GetComponent<BaseObject>().player.playerNumber == 2)
            {

                if (P2timer >= 0.0f)
                {
                    P1timer -= Time.deltaTime;
                    int min = Mathf.FloorToInt(P2timer / 60);
                    int sec = Mathf.FloorToInt(P2timer % 60);

                }
                if (P2timer <= 0.0f)
                {
                    P2timer = originalTimer;
                    GameManager.GetComponent<ROTHManager>().P2AddScore(pointValue);
                }

            }

            if (other.GetComponent<BaseObject>().player.playerNumber == 3)
            {

                if (P3timer >= 0.0f)
                {
                    P1timer -= Time.deltaTime;
                    int min = Mathf.FloorToInt(P3timer / 60);
                    int sec = Mathf.FloorToInt(P3timer % 60);

                }
                if (P3timer <= 0.0f)
                {
                    P3timer = originalTimer;
                    GameManager.GetComponent<ROTHManager>().P3AddScore(pointValue);
                }

            }

            if (other.GetComponent<BaseObject>().player.playerNumber == 4)
            {

                if (P4timer >= 0.0f)
                {
                    P1timer -= Time.deltaTime;
                    int min = Mathf.FloorToInt(P4timer / 60);
                    int sec = Mathf.FloorToInt(P4timer % 60);

                }
                if (P4timer <= 0.0f)
                {
                    P1timer = originalTimer;
                    GameManager.GetComponent<ROTHManager>().P4AddScore(pointValue);
                }

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Grabbable")
        {
            if (other.GetComponent<BaseObject>().player.playerNumber == 1)
            {
                P1timer = originalTimer;
            }

            if (other.GetComponent<BaseObject>().player.playerNumber == 2)
            {
                P3timer = originalTimer;
            }

            if (other.GetComponent<BaseObject>().player.playerNumber == 3)
            {
                P3timer = originalTimer;
            }

            if (other.GetComponent<BaseObject>().player.playerNumber == 4)
            {
                P4timer = originalTimer;
            }
        }
    }
}
