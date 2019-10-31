using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRespawn : MonoBehaviour
{
    public Transform RespawnPosition;
    public AudioSource SoundSource;
    public int ScoreLayer;
    public ScoreManager _ScoreManager;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == ScoreLayer)
        {
            collision.gameObject.transform.position = RespawnPosition.position;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(0, -2500, 0);
            SoundSource.Play();
            _ScoreManager.AddScore(ScoreLayer);
        }
    }
}
