using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    public Transform respawnPoint;
    private GameObject player;

    public void OnTriggerEnter(Collider other)
    {
        BaseObject p = other.GetComponent<BaseObject>();
        if (p != null)
        {
            Debug.Log("Respawn Me!!!");
            //player = p.player.getHips();


            // NOT lerp
            p.player.movePlayer(respawnPoint.transform);

            // Using LERP
            // https://answers.unity.com/questions/478307/im-using-translate-but-want-to-use-lerp-c.html
            //player.transform.position = Vector3.Lerp(player.transform.position, respawnPoint.transform.position, 1f);
        } 
    }
}
