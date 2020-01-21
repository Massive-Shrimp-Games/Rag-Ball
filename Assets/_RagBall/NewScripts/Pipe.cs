using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private TeamColor color;

    private RagballRuleset ruleset;
    private ParticleSystem confetti;

    void Start()
    {
        ruleset = GameObject.Find("Ruleset")?.GetComponent<RagballRuleset>();
        transform.GetChild(1).GetComponent<CPS>()._OnTriggerEnter += TriggerEnter;
        confetti = transform.GetChild(2).GetComponent<ParticleSystem>();
        Debug.LogFormat("Pipe color is {0}", color);
        if (color == TeamColor.Red)
        {
            ruleset.OnRedScore += OnScore;
            transform.GetChild(0).GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Pipe/RedPipe");
        }
        else if (color == TeamColor.Blue)
        {
            ruleset.OnBlueScore += OnScore;
            transform.GetChild(0).GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Pipe/BluePipe");
        }
    }

    private void OnDestroy()
    {
        if (color == TeamColor.Red)
        {
            ruleset.OnRedScore -= OnScore;
        }
        else if (color == TeamColor.Blue)
        {
            ruleset.OnBlueScore -= OnScore;
        }
        transform.GetChild(1).GetComponent<CPS>()._OnTriggerEnter -= TriggerEnter;
    }

    private void OnScore(GameObject player)
    {
        Game.Instance.SFX.PlayAudio("goal");
    }

    private void TriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject player = collision.gameObject.transform.root.GetChild(0).gameObject;
            if (player.GetComponent<Player>().color == color)
            {
                if (color == TeamColor.Red)
                {
                    ruleset.RedScore(player);
                }
                else
                {
                    ruleset.BlueScore(player);
                }
                confetti.Play();
            }   
        }
    }
}
