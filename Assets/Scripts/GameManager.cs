using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public GameObject player; //Ссылка на игрока
    [HideInInspector] public int currentCountEnemy { get; private set; }

    [Tooltip("Точка в которой появляется игрок после смерти")]
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

    public void GameOwer() //Игрок исчерпал запас своих жизней и игра заканчивается
    {

    }


}
