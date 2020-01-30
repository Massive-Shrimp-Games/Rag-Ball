using UnityEngine;
using System.Collections;

public class animControllerv2 : MonoBehaviour {


    // REFERENCES
    // https://www.youtube.com/watch?v=foM06C52Kd8
    // https://docs.unity3d.com/ScriptReference/Transform-parent.html


    // VARIABLES
    public Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }
 

    void Update()
    {

        // Forward Walk
        if (Input.GetKeyDown("w"))
        {
            anim.Play("Walk");
        }
        else if (Input.GetKeyUp("w"))
        {
            anim.Play("Idle");
        }


        // Backward Walk
        if (Input.GetKeyDown("s"))
        {
            anim.Play("Walkback");
        }
        else if (Input.GetKeyUp("s"))
        {
            anim.Play("Idle");
        }


        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("JumpHold");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.Play("JumpRel");
        }

        // Backward Walk
        if (Input.GetKeyDown("r"))
        {
            anim.SetBool("Holding", true);
            Debug.Log("Holding");
        }
        else if (Input.GetKeyUp("r"))
        {
            anim.SetBool("Holding", false);
        }

    }
}﻿