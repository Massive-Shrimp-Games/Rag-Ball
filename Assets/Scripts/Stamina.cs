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

    private Queue<Player.StaminaAbility> cooldowns;
    private bool isEmptying;

    private void Awake()
    {
        charges = maxCharge;
        isEmptying = false;
        cooldowns = new Queue<Player.StaminaAbility>();
    }

    private void Update() {
        //print(charges);
        print(cooldowns.Count);
    }

    // isEmptying isn't letting anything ge
    private void EmptyQueue(int playerNumber) {
        // One source -- if this is already emptying, don't touch it
        if (isEmptying) { return; }
        isEmptying = true;
        
        while (cooldowns.Peek() != null) {
            print("In the while loop!");
            // Wait for stamina recharge time and regain stamina
            StartCoroutine("WaitCooldownTimer");
            
            Player.StaminaAbility cd = cooldowns.Dequeue();
            int cost = (cd == Player.StaminaAbility.Jump) ? jumpCost : dashCost;
            charges += cost;
            OnStaminaChange(playerNumber, charges);
        }

        isEmptying = false;
    }

    public void AddCooldown(Player.StaminaAbility playerAbility, int playerNumber) {
        // Deplete stamina charges
        int cost = (playerAbility == Player.StaminaAbility.Jump) ? jumpCost : dashCost;
        charges -= cost;
        OnStaminaChange(playerNumber, charges);

        // Add cooldown, even if the queue is currently emptying itself
        cooldowns.Enqueue(playerAbility);

        // Immediately start cooldown timer
        EmptyQueue(playerNumber);
    }

    public bool CanAfford(Player.StaminaAbility playerAbility) {
        int cost = (playerAbility == Player.StaminaAbility.Jump) ? jumpCost : dashCost;
        return charges >= cost;
    }

    private IEnumerator WaitCooldownTimer()
    {
        yield return new WaitForSeconds(rechargeTime);
    }
}
