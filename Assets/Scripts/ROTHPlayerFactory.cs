using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTHPlayerFactory : PlayerFactory
{

    public TeamColor[] teamColors;

    protected override void Init()
    {
        for (int i = 0; i < Game.Instance.Controllers.Count(); i++) {
            CreatePlayer(i, spawnPoints[i], parent, teamColors[i], RagdollSize.Medium);
        }
    }
}
