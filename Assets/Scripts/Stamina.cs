using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
    public delegate void StaminaChange(int player, int stamina);
    public event StaminaChange OnStaminaChange;

    [SerializeField] private int maxCharge;
    [SerializeField] private int jumpCost;
    [SerializeField] private int dashCost;
    [SerializeField] private float rechargeTime;
 
    public int charges { get; private set; }

    private void Awake()
    {
        charges = maxCharge;
    }

    // isEmptying isn't letting anything ge
    private IEnumerator StartCooldown(int playerNumber, float abilityStartTime) {
        float replenishAt = abilityStartTime + rechargeTime;
        yield return new WaitUntil(() => Time.time > replenishAt);
        
        charges++;
        OnStaminaChange(playerNumber, charges);        
    }

    public void AddCooldown(int playerNumber) {
        // Deplete stamina charges
        charges--;
        OnStaminaChange(playerNumber, charges);

        // Immediately start cooldown timer
        StartCoroutine(StartCooldown(playerNumber, Time.time));
    }

    public bool CanAfford() {
        return charges > 0;
    }
}
