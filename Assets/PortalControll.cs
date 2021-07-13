using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalControll : MonoBehaviour
{
    [SerializeField] private int nextLevelIndex = 0;
    [SerializeField] GameObject[] enemys;
    [SerializeField] bool isOpen = false;


    public void OpeningPortal()
    {
        isOpen = true;
    }


    public void DamagePortal()
    {
        if(GameManager.instance.currentCountEnemy < GameManager.instance.startCountEnemy)
        {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int i = UnityEngine.Random.Range(0, enemys.Length);
        Instantiate(enemys[i], transform.position+transform.up,Quaternion.identity);
        GameManager.instance.currentCountEnemy++;
        Debug.Log("SpawnEnemy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isOpen) { return;}
            Debug.Log("NEXT LEVEL LOAD");

            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
