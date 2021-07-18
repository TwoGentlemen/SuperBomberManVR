using UnityEngine;
using NEW;
public class ClockBombBonus : BaseBonus
{
    protected override void BehaviourBonus()
    {
        var player = Player.instanstance;
        if (player == null) { Debug.LogWarning("Not Player!"); return; }

        player.SetCurrentTypeBomb(TypeBomb.detonatorBomb);
    }
}
