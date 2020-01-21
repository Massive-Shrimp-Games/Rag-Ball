using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    RagballRuleset ruleset;
    private ParticleSystem confetti;

    [SerializeField] private TeamColor color;

    private Material redMaterial;
    private Material blueMaterial;

    void Start()
    {
        redMaterial = Resources.Load<Material>("Materials/Pipe/RedPipe");
        blueMaterial = Resources.Load<Material>("Materials/Pipe/BluePipe");
        ruleset = GameObject.Find("Ruleset")?.GetComponent<RagballRuleset>();
        ruleset.OnRedScore += OnScore;
        transform.GetChild(1).GetComponent<CPS>()._OnTriggerEnter += TriggerEnter;
        confetti = transform.GetChild(2).GetComponent<ParticleSystem>();
        Debug.LogFormat("Pipe color is {0}", color);
        if (color == TeamColor.Red)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = redMaterial;
        }
        else if (color == TeamColor.Blue)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = blueMaterial;
        }
    }

    private void OnDestroy()
    {
        ruleset.OnRedScore -= OnScore;
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
                ruleset.RedScore(player);
                confetti.Play();
            }   
        }
    }
}
