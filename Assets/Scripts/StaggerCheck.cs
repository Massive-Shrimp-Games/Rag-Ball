using System.Collections;
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
        if(Game.Instance == null) return;
        GameObject enemy;
        if (other.gameObject.tag == "Grabbable")
        {
            enemy = other.transform.root.gameObject;
            PlayerSize psize = enemy.transform.GetComponent<PlayerSize>();
            Player pscript = null;
            if(psize.size == Size.Small)
            {
                pscript = enemy.transform.GetChild(0).GetChild(0).GetChild(1).GetComponent<Player>();
            } else if(psize.size == Size.Medium)
            {
                pscript = enemy.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<Player>();
            } else if(psize.size == Size.Large)
            {
                pscript = enemy.transform.GetChild(2).GetChild(0).GetChild(1).GetComponent<Player>();
            }
            if (enemy != null && pscript != null)
            {
                bool isDashing = pscript.dashing;
                OnStaggerSelf(isDashing, psize.color);
            }
        }

    }
}