using UnityEngine;

public class AddSpeed : BaseBonus
{
    [Tooltip("Add value speed player")]
    [SerializeField] float addSpeed = 0.3f;
    protected override void BehaviourBonus()
    {
        var buffer = GameManager.instance;
        if(buffer == null) { Debug.LogWarning("Not GameManager!"); return;}

        buffer.PlayerControll.AddSpeed(addSpeed);
    }
}
