using UnityEngine;
using NEW;
public class AddBomb : BaseBonus
{
    protected override void BehaviourBonus()
    {
        var player = Player.instanstance;
        if (player == null) { Debug.LogWarning("Not Player!"); return; }

        player.SetCountBomb(TypeSetMode.Add);
    }
}
