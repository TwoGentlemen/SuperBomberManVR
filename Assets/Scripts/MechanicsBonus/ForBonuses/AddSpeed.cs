using UnityEngine;

using NEW;
public class AddSpeed : BaseBonus
{
    [Tooltip("Add value speed player")]
    [SerializeField] float addSpeed = 0.5f;
    protected override void BehaviourBonus()
    {
        var player = Player.instanstance;
        if (player == null) { Debug.LogWarning("Not Player!"); return; }

        player.SetSpeed(TypeSetMode.Add);
    }
}
