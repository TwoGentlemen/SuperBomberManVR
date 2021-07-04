using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveObjectToGrid))]
public class EnemyBaseAI : MonoBehaviour
{
    [Tooltip("Скорость перемещения персонажа")]
    [SerializeField] private int moveSpeed = 3;

    Vector3 targetPos;

    private void Start()
    {
        GetNextTarget();
    }

    private void FixedUpdate()
    {
    
        if (Vector3.Distance(targetPos, transform.position) <= 0.1f)
        { 
            GetNextTarget();
        }
        else
        {
            SetDistanation(targetPos);
        }
        
    }

    private void GetNextTarget()
    {
        targetPos = GridManager.instance.GetRundomNextPoint(transform);
        targetPos = new Vector3(targetPos.x, transform.position.y, targetPos.z);
    }

    private void SetDistanation(Vector3 pos)
    {
        Vector3 rot = new Vector3(pos.x,transform.position.y,pos.z);
        pos = new Vector3(pos.x,transform.position.y,pos.z);

        if (Vector3.Distance(pos, transform.position) <= 0.1f) { return; }
        Vector3 dir = (pos - transform.position).normalized;    

        transform.LookAt(rot);
        transform.Translate(dir*moveSpeed*Time.deltaTime,Space.World);
    }

    private void OnDestroy()
    {
        if(GameManager.instance == null) { return;}
        GameManager.instance.DeathEnemy();
    }
}
