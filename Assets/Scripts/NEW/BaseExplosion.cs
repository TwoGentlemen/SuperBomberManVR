using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NEW;
using System;

public class BaseExplosion : MonoBehaviour
{
    private int radius = 1;
    protected float timerStartExplosion = 4f;

    private Vector2Int indexCell;
   
    private void Start()
    {
        if(GridManager.instance == null || Player.instanstance == null) { Debug.LogError("Not GridManager");}
        radius = Player.instanstance.GetRadiusExplosion();
        indexCell = GridManager.instance.GetIndexCell(transform.position);
        ActivationBomb();
    }

    protected virtual void ActivationBomb()
    {
        Invoke("Explosion", timerStartExplosion);
    }

    protected virtual void Explosion()
    {
        var objectsInRadius = GridManager.instance.Explosion(transform.position,radius);

        foreach (var item in objectsInRadius)
        {
            switch (item.tag)
            {
                case "Player": Player.instanstance.Damage(); break;
                case "Enemy": item.GetComponent<EnemyBaseAI>().Damage(); break;
                case "DestructableObject": Destroy(item); break;

                default: break;
            }
        }
        GridManager.instance.SetObjectInCell(null, indexCell);
        Destroy(gameObject);
    }

}
