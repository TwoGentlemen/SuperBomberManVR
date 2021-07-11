using UnityEngine;

public class ClockBombBonus : BaseBonus
{
    protected override void BehaviourBonus()
    {
        GameManager.instance.spawnBomb.SetCurrentTypeBomb(TypeBomb.clockBomb);
    }
}
