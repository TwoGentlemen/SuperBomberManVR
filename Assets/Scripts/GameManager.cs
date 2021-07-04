using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //Ссылка на игрока
    [HideInInspector] public int currentCountEnemy { get; private set; }


    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    private void Start()
    {
        currentCountEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        Debug.Log("Всего врагов "+currentCountEnemy);
    }

    public void DeathEnemy()
    {
        currentCountEnemy--;
        Debug.Log("Врагов осталось" + currentCountEnemy);

        if(currentCountEnemy <= 0)
        {
            GameWin();
        }
    }


    public void GameWin()
    {
        Debug.Log("----GAME WIN----");
    }

    public void GameOwer() //Игрок исчерпал запас своих жизней и игра заканчивается
    {
        Debug.Log("----GAME OWER----");
    }


}
