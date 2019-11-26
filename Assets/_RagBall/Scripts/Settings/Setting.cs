using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Setting is an Abstract Class to define all other settings
/// This is a Singleton pattern
/// Each setting should affect ONE and only ONE thing
/// If a setting gets too large, BREAK IT UP, or expand it into a FULL FEATURE
/// </summary>
public abstract class Setting : MonoBehaviour
{

    /// <summary>
    /// A Setting must have a SINGLE PRIMARY parameter which it changes
    /// </summary>
    private Object mySetting;

    /// <summary>
    /// A setting must set its default values
    /// </summary>
    public Setting()
    {

    }


}
