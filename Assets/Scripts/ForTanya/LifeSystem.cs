using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{


    //������ ��� ���������


    //���������� ������
    [SerializeField] [Range(1, 100)] private int healthPoints = 3;
    //��������� ����������� �����
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


    // ����� ���� ��� ������
    private void Dead()
    {
        //������� ��������� ����
    }
}
