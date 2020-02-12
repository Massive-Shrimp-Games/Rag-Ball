﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaggerCheck : MonoBehaviour
{
    public delegate void StaggerSelf(bool enemyDashing, TeamColor enemyColor);

    public event StaggerSelf OnStaggerSelf;

    // If the person that ran into us was dashing, stagger self.
    // Check if we hit hips. Need a stronger system to check if we collide with Player
    // Can't check player tag because self is hips, which collides with Player.
    private void OnTriggerEnter(Collider other)
    {
        Player enemy;
        if (other.gameObject.tag == "Grabbable")
        {
            enemy = other.gameObject.transform.parent.parent.GetComponent<Player>();
            if (enemy != null)
            {
                OnStaggerSelf(enemy.dashing, enemy.color);
            }
        }

    }
}