using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //Ссылка на игрока
    [HideInInspector] public int currentCountEnemy { get; private set; }

    [Header("Ссылки на объекты управления")]
    public SpawnBomb spawnBomb;

    [Space(3)]
    public UnityEvent onGameOwer;
    public UnityEvent onGameWin;


    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
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
        Time.timeScale = 0;
        onGameWin?.Invoke();
    }

    public void GameOwer() //Игрок исчерпал запас своих жизней и игра заканчивается
    {
        Debug.Log("----GAME OWER----");
        Time.timeScale = 0;
        onGameOwer?.Invoke();
    }


}
