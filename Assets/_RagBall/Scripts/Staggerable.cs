using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staggerable : MonoBehaviour
{
    // VARIABLES

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



    // NOTES

    // https://forum.unity.com/threads/enable-disable-a-joint.24525/
    // https://forum.unity.com/threads/configurable-joints-in-depth-documentation-tutorial-for-dummies.389152/
    // https://docs.unity3d.com/Manual/class-ConfigurableJoint.html
    // https://docs.unity3d.com/Manual/class-CharacterJoint.html
    // https://answers.unity.com/questions/868898/make-gameobject-always-vertical-to-terrain.html


}
