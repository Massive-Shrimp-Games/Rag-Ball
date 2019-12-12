using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staggerable : MonoBehaviour
{
    // VARIABLES

    /*
    // Logic
    public bool iCanStagger;

    // Torso
    public CharacterJoint Spine_CJ;
    public CharacterJoint Head_CJ;

    // Left
    public ConfigurableJoint ThighL_CJ;
    public ConfigurableJoint ShinL_CJ;

    // Right
    public ConfigurableJoint ThighR_CJ;
    public ConfigurableJoint ShinR_CJ;
    */

    //private RigidbodyConstraints hipsRBC;
    private Rigidbody maHips;
    public PlayerManager ourSavior;
    public int myPlayer = -666;
    private int maSpeed;
    public string grabMode;
    public Animator maAnimator;

    private void Awake()
    {
        //Debug.Log("STAGGER: READY");
        //hipsRBC = this.gameObject.GetComponent<Rigidbody>().constraints;
        maHips = this.gameObject.GetComponent<Rigidbody>();
        myPlayer = this.gameObject.GetComponent<Grabbable>().myPlayer;
        grabMode = this.gameObject.GetComponent<Grabbable>().grabMode;
        maAnimator = this.gameObject.transform.parent.parent.parent.GetChild(1).GetComponent<animController>().anim;
    }

    public void Stagger()
    {
        //Debug.Log("STAGGER:\n!!!!!!!!!!!!!!!!!!!!!!!!!!!\n!!!!!!!!!!!!!!!!!!!!!");
        maHips.constraints = RigidbodyConstraints.None;
        grabMode = "stunned";
        maAnimator.enabled = false;
        //Debug.Log(hipsRBC);
    }

    public void UnStagger()
    {
        //Debug.Log("STAGGER:\n????????????????????????????\n?????????????????????");
        maHips.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        //maHips.constraints = RigidbodyConstraints.FreezeRotationY;
        //maHips.constraints = RigidbodyConstraints.FreezeRotationZ;
        maAnimator.enabled = true;
        grabMode = "free";
        //Debug.Log(hipsRBC);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Force Direction: " + collision.contacts[0].normal);

        // Is the collision normal or above surface?


        // Yes, damage the player
        float daSpeed = collision.relativeVelocity.magnitude;
        if (daSpeed > 2)
            maSpeed = Convert.ToInt32(daSpeed);
            Debug.Log("\nI HIT SOMETHING OUCH! " + maSpeed + "\n" + "Direction: " + collision.contacts[0].normal);
        if (maSpeed > 5)
        {
            ourSavior.DoStagger(myPlayer, maSpeed);
            ourSavior.AudioManager.transform.Find("collision_AudioSource").GetComponent<AudioSource>().Play();
        }

        // else, ignore it, player is jumping
    }

    // NOTES
    // Joints
    // https://forum.unity.com/threads/enable-disable-a-joint.24525/
    // https://forum.unity.com/threads/configurable-joints-in-depth-documentation-tutorial-for-dummies.389152/
    // https://docs.unity3d.com/Manual/class-ConfigurableJoint.html
    // https://docs.unity3d.com/Manual/class-CharacterJoint.html
    // https://answers.unity.com/questions/11460/how-do-i-lock-out-a-axis.html
    // Scripts
    // https://answers.unity.com/questions/1412772/how-to-stop-animation-from-playing-in-c.html
    // https://docs.unity3d.com/ScriptReference/Transform.GetChild.html
    // Constraints
    // https://docs.unity3d.com/ScriptReference/Rigidbody-constraints.html
    // Surface Normals
    // https://docs.unity3d.com/ScriptReference/ContactPoint-normal.html
}
