using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //Ссылка на игрока
    [HideInInspector] public int currentCountEnemy { get; set; }
    [HideInInspector] public int startCountEnemy { get; private set;}

    [Header("Ссылки на объекты управления")]
    public SpawnBomb SpawnBomb;
    public PlayerControll PlayerControll;
    public AudioManager AudioManager;
    public PortalControll PortalControll;

    [Space(3)]
    public UnityEvent onGameOwer;
    public UnityEvent onLevelWin;


    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1;
        currentCountEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
        startCountEnemy = currentCountEnemy;

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
        Debug.Log("----Level WIN----");
        PortalControll.OpeningPortal();
        onLevelWin?.Invoke();
    }

    public void GameOwer() //Игрок исчерпал запас своих жизней и игра заканчивается
    {
        Debug.Log("----GAME OWER----");
        Time.timeScale = 0;
        onGameOwer?.Invoke();
    }


}
