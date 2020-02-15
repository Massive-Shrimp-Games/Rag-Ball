using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagOfTheHill : MonoBehaviour
{
    public GameObject player;
    public GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "RagDoll")
        {
            

            if (player.GetComponent<Player>().playerNumber == 0)
            {
                GameManager.GetComponent<ROTHManager>().P1Score +=1;
            }
        }
    }
}
