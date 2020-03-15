using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public TeamColor color;

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
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Court_Objects/RedPipe");
        }
        else if (color == TeamColor.Blue)
        {
            ruleset.OnBlueScore += OnScore;
            transform.GetChild(0).GetChild(0).GetComponent<Renderer>().material = Resources.Load<Material>("Materials/Court_Objects/BluePipe");
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

    private void OnScore(GameObject player, int score)
    {
        Game.Instance.SFX.PlayAudio("goal");
    }

    private void TriggerEnter(Collider collision)
    {
        Debug.Log("Something hit me");
        if (collision.gameObject.tag == "Grabbable")
        {
            Debug.Log("Player entered a goal");
            BaseObject baseObject = collision.GetComponent<BaseObject>();
            if (baseObject == null) return;
            Player player = baseObject.player;
            if (player != null && player.color == color)
            {
                if (color == TeamColor.Red)
                {
                    Debug.Log("player has same color");
                    ruleset.BlueScore(player.gameObject);
                }
                else
                {
                    ruleset.RedScore(player.gameObject);
                }
                confetti.Play();
            }
            else{
                Debug.Log("Hello, Im being grabbed"); 
            }  
        }
    }
}
