

//Description
/* PlayerAttack uses PlayerHealth to interact with other players.
 * The player does not necessarily attack, no damage is dealt.
 * Instead, messages are passed and the physics system takes over.
 * This script needs a player, target, and health scripts for the player and target.
 */


//Declarations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerAttack Class
public class PlayerAttack : MonoBehaviour
{


    //Temporary Variables
    private float AttackTimer;
    public float AttackSpeed = 0.5f;
    public Transform AttackDirection;
    bool ThingInRange;


    //Messaging Variables
    GameObject Target;
    Rigidbody TargetRigidbody;
    PlayerHealth ThisPlayerHealth;
    PlayerMove ThisPlayerMove;


    //Stats Variables
    private float ThrowForce = 60f;
    private float HoldTime;
    private float HoldTimer;



    private GameObject collidedObject = null;

    //Awake
    void Awake ()
    {
        //TEMP: Reset AttackTimer
        AttackTimer = 0f;

        //Reset HoldTimer
        HoldTimer = 0f;

        //Find Stats
        ThisPlayerHealth = GetComponent<PlayerHealth>();

    }


    //Update
    void Update ()
    {
        //Check for what player wants to do

        //Player wants to grab and is in range
        if (Input.GetMouseButtonDown(1) && ThingInRange)
        {
            Grab ();
        }

        //Player wants to throw
        else if (Input.GetMouseButtonDown(0))
        {
            Throw ();
        }

        collidedObject = Target;
        if (collidedObject != null)
        {
            Vector3 offset = new Vector3(0, 0, 1);
            transform.position = collidedObject.transform.position + offset;
        }
    }


    //Grab
    void Grab ()
    {
        TargetRigidbody = Target.GetComponent<Rigidbody>();

    }


    //Throw
    void Throw ()
    {
        
        TargetRigidbody.AddForce(transform.forward * ThrowForce);
    }


    //ONTRIGGERENTER
    //Checks if something in range is the player
    void OnTriggerEnter(Collider Other)
    {
        if (Other.GetComponent<Collider>().gameObject.layer == 8 || Other.GetComponent<Collider>().gameObject.layer == 9)
        { 
            ThingInRange = true;
            Target = Other.GetComponent<Collider>().gameObject;
            Debug.Log("Hit something");
        }
    }



}

