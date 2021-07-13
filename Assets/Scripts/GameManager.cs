using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //������ �� ������
    [HideInInspector] public int currentCountEnemy { get; set; }
    [HideInInspector] public int startCountEnemy { get; private set;}

    [Header("������ �� ������� ����������")]
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

        Debug.Log("����� ������ "+currentCountEnemy);
    }

    public void DeathEnemy()
    {
        currentCountEnemy--;
        Debug.Log("������ ��������" + currentCountEnemy);

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

    public void GameOwer() //����� �������� ����� ����� ������ � ���� �������������
    {
        Debug.Log("----GAME OWER----");
        Time.timeScale = 0;
        onGameOwer?.Invoke();
    }


}
