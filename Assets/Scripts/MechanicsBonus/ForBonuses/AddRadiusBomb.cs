using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRadiusBomb : BaseBonus
{
    protected override void BehaviourBonus()
    {
       GridManager.instance.AddRadiusBombExplosion();
    }
}
