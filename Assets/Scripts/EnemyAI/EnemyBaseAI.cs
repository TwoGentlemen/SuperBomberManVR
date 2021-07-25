using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NEW;
using System;

[RequireComponent(typeof(MoveObjectToGrid))]
public class EnemyBaseAI : MonoBehaviour
{
    [Tooltip("Скорость перемещения персонажа")]
    [SerializeField] private int moveSpeed = 3;
    [SerializeField] private int healthPoint = 1;

    private Vector3 targetPos;
    private bool isMoveEnemy = true;

    private void Start()
    {

        GameManager.instance.onStartGame += StartGame;
        GameManager.instance.onStopGame += StopGame; 
        GetNextTarget();

        gameObject.SetActive(false);
    }

    private void StopGame()
    {
        gameObject.SetActive(false);
    }

    private void StartGame()
    {
        gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if(!isMoveEnemy)
            return;
    
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
       
        if (!GridManager.instance.isEmptyCellNotPlayer(GridManager.instance.GetIndexCell(pos)) &&
           GridManager.instance.GetObjectInCell(GridManager.instance.GetIndexCell(pos)) != gameObject)
        {
            GetNextTarget();
            return;
        }

        Vector3 rot = new Vector3(pos.x,transform.position.y,pos.z);
        pos = new Vector3(pos.x,transform.position.y,pos.z);

        if (Vector3.Distance(pos, transform.position) <= 0.1f) { return; }
        Vector3 dir = (pos - transform.position).normalized;    

        transform.LookAt(rot);
        transform.Translate(dir*moveSpeed*Time.deltaTime,Space.World);
    }

    IEnumerator PauseMoveEnemy()
    {
        isMoveEnemy = false;
        yield return new WaitForSeconds(1f);
        isMoveEnemy = true;
    }
    public void Damage(int damage = 1)
    {
        healthPoint-=damage;

        StartCoroutine(PauseMoveEnemy());

        if (healthPoint <= 0)
            DeathEnemy();
    }

    private void DeathEnemy()
    {
        if(GameManager.instance == null)
            return;

        GameManager.instance.DeathEnemy();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.instanstance.Damage();
        }
    }

    private void OnDestroy()
    {
        GameManager.instance.onStartGame -= StartGame;
        GameManager.instance.onStopGame -= StopGame;
    }
}
