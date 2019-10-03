

//Description
/* Maybe later I flesh this out...
 * 
 */


//Declarations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerHealth
public class PlayerHealth : MonoBehaviour
{


    //Messaging Variables
    PlayerMove ThisPlayerMove;
    PlayerAttack ThisPlayerAttack;


    //Model Variables
    public float Mass;
    public int Stamina;
    public string ThisClass;


    //UI Variables


    //TEMP Variables
    public float Balance;
    public float DashSpeed = 12f;


    //Effects Variables


    //Awake
    void Awake()
    {
        ThisPlayerAttack = GetComponent<PlayerAttack>();
        ThisPlayerMove = GetComponent<PlayerMove>();
        Balance = 100f;
        Stamina = 3;
        Mass = 120f;
        ThisClass = "Medium";
    }


    //Update
    void Update()
    {
        CheckBalance();
    }


    //TEMP CheckBalance
    void CheckBalance()
    {

    }

}

