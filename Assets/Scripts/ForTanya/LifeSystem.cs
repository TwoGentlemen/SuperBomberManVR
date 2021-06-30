using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{


    //Скрипт для переделки


    //Количество жизней
    [SerializeField] [Range(1, 100)] private int healthPoints = 3;
    //Начальное колличество жизни
    private int startHp;

    void Start()
    {
        startHp = healthPoints;
    }

    public void DamagePlayer()
    {

        healthPoints -= 1;





        if (healthPoints <= 0)
        {
            Dead();
        }
    }


    // Вызов меню при смерти
    private void Dead()
    {
        //сделать появление меню
    }
}
