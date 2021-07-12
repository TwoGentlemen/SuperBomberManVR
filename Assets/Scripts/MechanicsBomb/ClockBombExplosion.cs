using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBombExplosion : BombExplossion
{
  
    protected override void ActivateExplosion()
    {
        var buffer = GameManager.instance;
        if (buffer == null) {Debug.LogWarning("Not GameManager!"); return; }

        buffer.PlayerControll.AddClockBomb(this);
    }

    public void ActivateClockExplosion()
    {
        Explosion();
    }
}
