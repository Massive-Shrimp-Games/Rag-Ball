using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    RagballRuleset ruleset;
    [SerializeField] private string color;

    void Start()
    {
        ruleset = GameObject.Find("Ruleset")?.GetComponent<RagballRuleset>();
        ruleset.OnRedScore += OnScore;
    }

    private void OnDestroy()
    {
        ruleset.OnRedScore -= OnScore;
    }

    private void OnScore(GameObject player)
    {
        //question for jake. Why is this happening in goal from a subscription to an event that is triggered in the same script?
        Game.Instance.SFX.PlayAudio("goal");
    }

    public void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject.transform.root.GetChild(0).gameObject;
            if(player.GetComponent<Player>().color == color)
            {
                ruleset.RedScore(player);
            }   
        }
    }
}
