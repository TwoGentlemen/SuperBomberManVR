using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBombExplosion : BombExplossion
{
  
    protected override void ActivateExplosion()
    {
        GameManager.instance.playerControllVR.AddClockBomb(this);
    }

    public void ActivateClockExplosion()
    {
        Explosion();
    }
}
