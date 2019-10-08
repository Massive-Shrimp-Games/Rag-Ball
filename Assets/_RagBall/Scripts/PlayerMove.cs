

//Description
/* PlayerMove translates and rotates the player model on the game world.
 * 
 * It needs a player model with rigidbody,
 * and a Plane for the player to stand on.
 * 
 * Also includes special abilities.
 * Jumping and Dashing
 */


//Declarations
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//PlayerMove Class
public class PlayerMove : MonoBehaviour
{


    //Variables
    public float MoveSpeed = 6f;
    Vector3 Movement;
    Rigidbody PlayerRigidbody;
    public int Floor;
    float CameraRayLength = 100f;
    PlayerHealth ThisPlayerHealth;


    //Awake
    void Awake ()
    {
        PlayerRigidbody = GetComponent<Rigidbody>();
        ThisPlayerHealth = GetComponent<PlayerHealth>();
    }


    //FixedUpdate
    void FixedUpdate ()
    {
        //Raw Input for Snappy Movement
        //Horizontal maps to the "A" and "D" keys
        //Vertical maps to the "W" and "S" keys
        float H = Input.GetAxisRaw("Horizontal");
        float V = Input.GetAxisRaw("Vertical");

        //TEMP: Detect if jump requested and available
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump ();
        }

        //TEMP: Detect if Dash requested and available
        if (Input.GetKeyDown(KeyCode.LeftShift) && ThisPlayerHealth.Stamina > 0)
        {
            Dash ();
        }

        //Separate Functions for modification
        Move (H, V);
        Turn ();
    }


    //Move
    void Move (float H, float V)
    {
        //Point Vector along X, Y Input
        Movement.Set(H, 0f, V);

        //Set Magnitude per frame at the correct Speed and magnitude
        Movement = Movement.normalized * MoveSpeed * Time.deltaTime;
        
        //Apply Vector to Player at Player's position
        PlayerRigidbody.MovePosition(transform.position + Movement);
    }


    //Turn
    void Turn ()
    {
        //Creates and binds a ray to the Mouse
        Ray CameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        //Gives information to other scripts
        RaycastHit FloorHit;

        //Casts the ray and checks if it hits
        if (Physics.Raycast(CameraRay, out FloorHit, CameraRayLength, Floor))
        {
            //Distance from player to aimpoint
            Vector3 PlayerToMouse = FloorHit.point - transform.position;
            
            //Prevent Player from rotating up and down
            PlayerToMouse.y = 0f;
            
            //Set direction of player to mouse
            Quaternion NewRotation = Quaternion.LookRotation(PlayerToMouse);
            
            //Move the player model by the angle
            PlayerRigidbody.MoveRotation(NewRotation);
        }
    }


    //TEMP: Dash
    //Uses regular Rigidbody manipulation
    void Dash ()
    {
        //Apply force to player in direction of travel
        PlayerRigidbody.AddForce(transform.forward * ThisPlayerHealth.DashSpeed);
    }


    //TEMP: Jump
    //Uses regular Rigidbody manipulation
    void Jump ()
    {
        //Apply force to player vertically
        PlayerRigidbody.AddForce(transform.up * ThisPlayerHealth.DashSpeed);
    }


}

