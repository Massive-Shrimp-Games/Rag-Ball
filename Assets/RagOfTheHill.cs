using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagOfTheHill : MonoBehaviour
{
    public GameObject player;
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
                Debug.Log("Maestro Can't Save Us Now");
            }
        }
    }
}
