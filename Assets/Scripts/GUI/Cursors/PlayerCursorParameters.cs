using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="PlayerCursorParameters", menuName="ScriptableObjects")]
public class PlayerCursorParameters : ScriptableObject
{
    public GameObject prefab;
    public int playerNumber;
}
