using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NEW;
public class AddRadiusBomb : BaseBonus
{
    protected override void BehaviourBonus()
    {
        var player = Player.instanstance;
        if (player == null) { Debug.LogWarning("Not Player!"); return; }

        player.SetCountRadiusExplosion(TypeSetMode.Add);
    }
}
