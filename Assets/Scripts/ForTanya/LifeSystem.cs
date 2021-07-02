using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    //нужно реализовать показ количество жизней самому игроку
    //делать эффект через канвас или нет?

    private Vector3 Resp;

    //Количество жизней
    [SerializeField] [Range(1, 100)] private int healthPoints = 3;


    public void Start()
    {
        Resp = transform.position;
    }

    public void DamagePlayer()
    {

        healthPoints -= 1;

        // тут должен быть эффект

        if (healthPoints <= 0)
        {
            Dead();
            return;
        }

        transform.position = Resp;
    }


    private void Dead()
    {
        //сделать появление меню
    }
}
