using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> UILocations;
    [SerializeField] private GameObject UIPrefab;
    [SerializeField] private Sprite[] staminas;

    [SerializeField] private Sprite REDPLAYER;
    [SerializeField] private Sprite BLUEPLAYER;

    private Player[] players;
    private GameObject[] UIS;
    void Start()
    {
        if (Game.Instance == null) return;
       
        players = FindObjectsOfType<Player>();
        UIS = new GameObject[players.Length];
        
        foreach(Player p in players)
        {
            int index = p.playerNumber;
            //instantiates UIS based on number of players and assigns to the locations //NOTE: WILL THROW ERROR IF MORE PLAYERS THAN STAMINA POSITIONS
            UIS[index] = Instantiate(UIPrefab,UILocations[index].transform.position,Quaternion.identity,gameObject.transform);

            if(p.color == TeamColor.Red)
            {
                UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = REDPLAYER;
            } else if (p.color == TeamColor.Blue)
            {
                UIS[index].gameObject.transform.GetChild(0).GetComponent<Image>().sprite = BLUEPLAYER;
            }
            //sets stamina sprite
            UIS[index].transform.GetChild(1).GetComponent<Image>().sprite = staminas[5];
            //Subscribes OnExert to every player
            p.OnPlayerExertion += OnExert;
        }
    }
    private void OnDestroy()
    {
        
        foreach(Player p in players)
        {
            p.OnPlayerExertion -= OnExert;
        }
    }
    private void OnExert(int player, int stamina)
    {
        Debug.Log("Player: " + player + " Stamina: " + stamina);
        UIS[player].transform.GetChild(1).GetComponent<Image>().sprite = staminas[stamina];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
