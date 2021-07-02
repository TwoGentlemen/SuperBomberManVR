using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //������ �� ������
    [HideInInspector] public int currentCountEnemy { get; private set; }


    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    private void Start()
    {
        currentCountEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;
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
        Debug.Log("----GAME WIN----");
    }

    public void GameOwer() //����� �������� ����� ����� ������ � ���� �������������
    {
        Debug.Log("----GAME OWER----");
    }


}
