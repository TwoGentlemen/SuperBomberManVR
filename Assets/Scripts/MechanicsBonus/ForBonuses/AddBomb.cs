using UnityEngine;

public class AddBomb : BaseBonus
{
    protected override void BehaviourBonus()
    {
        var buffer = GameManager.instance;
        if (buffer == null) { Debug.LogWarning("Not GameManager!"); return; }

        buffer.SpawnBomb.AddBombQuantityInRow();
    }
}
