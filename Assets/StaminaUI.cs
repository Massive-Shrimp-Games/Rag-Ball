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

    [SerializeField] private Sprite redSmall;
    [SerializeField] private Sprite redMedium;
    [SerializeField] private Sprite redLarge;

    [SerializeField] private Sprite blueSmall;
    [SerializeField] private Sprite blueMedium;
    [SerializeField] private Sprite blueLarge;

    [SerializeField] private Player[] players;
    private GameObject[] UIS;
    void Start()
    {
        StartCoroutine("WaitForStart");
        
    }
    private void OnDestroy()
    {
        foreach (Player pl in players)
        {
            pl.OnPlayerExertion -= OnExert;
        }
    }
    private void OnStaminaChange(int player, int stamina)
    {
        UIS[player].transform.GetChild(1).GetComponent<Image>().sprite = staminas[stamina];
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForEndOfFrame();

        players = FindObjectsOfType<Player>();
        UIS = new GameObject[players.Length];

        foreach (Player p in players)
        {
            int index = p.playerNumber;
            //instantiates UIS based on number of players and assigns to the locations
            //NOTE: WILL THROW ERROR IF MORE PLAYERS THAN STAMINA POSITIONS
            UIS[index] = Instantiate(UIPrefab, UILocations[index].transform.position, Quaternion.identity, gameObject.transform);

            if (p.color == TeamColor.Red)
            {
                if (p.size == RagdollSize.Small) { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = redSmall;}
                else if (p.size == RagdollSize.Medium) { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = redMedium; }
                else { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = redLarge; }
            }
            else if (p.color == TeamColor.Blue)
            {
                if (p.size == RagdollSize.Small) { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = blueSmall; }
                else if (p.size == RagdollSize.Medium) { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = blueMedium; }
                else { UIS[index].transform.GetChild(0).GetComponent<Image>().sprite = blueLarge; }
            }
            //sets stamina sprite
            UIS[index].transform.GetChild(1).GetComponent<Image>().sprite = staminas[5];
            //Subscribes OnExert to every player
            p.OnPlayerExertion += OnExert;
        }
    }
}
