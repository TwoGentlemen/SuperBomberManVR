using UnityEngine;

public class ClockBombBonus : BaseBonus
{
    protected override void BehaviourBonus()
    {
        var buffer = GameManager.instance;
        if (buffer == null) { Debug.LogWarning("Not GameManager!"); return; }

        buffer.SpawnBomb.SetCurrentTypeBomb(TypeBomb.clockBomb);
    }
}
