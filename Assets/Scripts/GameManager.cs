using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //������ �� ������
    [HideInInspector] public int currentCountEnemy { get; private set; }

    [Tooltip("����� � ������� ���������� ����� ����� ������")]
    [SerializeField] private Transform spawnPlayer;

    private void Awake()
    {
        if(instance != null) { Debug.LogError("Instance!!!");}

        instance = this;
    }

    public void PlayerDeath()
    {
        player.transform.position = spawnPlayer.position;
    }

    public void GameOwer() //����� �������� ����� ����� ������ � ���� �������������
    {

    }


}
