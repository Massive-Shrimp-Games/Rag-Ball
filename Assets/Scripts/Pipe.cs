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
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Player entered a goal");
            GameObject player = collision.gameObject.transform.root.GetChild(1).GetChild(1).GetChild(0).gameObject;
            if (player.GetComponent<Player>().getHips().tag == "Grabbable"){
                if (player.transform.root.GetChild(1).GetComponent<PlayerSize>().color == color)
                {
               
                    if (color == TeamColor.Red)
                    {
                        Debug.Log("player has same color");
                        ruleset.BlueScore(player.transform.GetChild(1).GetChild(0).gameObject);
                    }
                    else
                    {
                        ruleset.RedScore(player.transform.GetChild(1).GetChild(0).gameObject);
                    }
                    confetti.Play();
                } 
            }
            else{
                Debug.Log("Hello, Im being grabbed"); 
            }  
        }
    }
}
