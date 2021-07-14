using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    //нужно реализовать показ количество жизней самому игроку
    //делать эффект через канвас или нет?

    private Vector3 Resp;

    //Количество жизней
    private int healthPoints = 3;
    [SerializeField] GameObject[] imageHP;

    [SerializeField] float timeOneLive = 60; //Время одной жизни 
    [SerializeField] Image imageLiveTimer;


    public void Start()
    {
        healthPoints = GameManager.instance.PlayerStats.hp;

        Resp = transform.position;

        for (int i = 0; i < healthPoints; i++)
        {
            imageHP[i].SetActive(true);
        }
         
        StartCoroutine(LiveTime());
    }

    IEnumerator LiveTime()
    {
        float incriment = 1/(timeOneLive*100);
        float timer = 1;
        imageLiveTimer.fillAmount = timer;

        while (timer>0)
        {
            yield return new WaitForSeconds(0.01f);
            timer-=incriment;
            timer = Mathf.Clamp(timer,0,1);
            imageLiveTimer.fillAmount = timer;
        } 

        DamagePlayer();

        

    }

    public void DamagePlayer()
    {

        healthPoints -= 1;
        GameManager.instance.PlayerStats.hp = healthPoints;

        // тут должен быть эффект

        if (healthPoints <= 0)
        {
            imageHP[0].SetActive(false);
            Dead();
            return;
        }

        imageHP[healthPoints].SetActive(false);

        transform.position = Resp;
        GameManager.instance.SpawnBomb.SetCurrentTypeBomb(TypeBomb.defaultBomb);

        StopAllCoroutines();
        StartCoroutine(LiveTime());
    }


    private void Dead()
    {
       GameManager.instance.GameOwer();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DamagePlayer();
            Debug.Log("Игрок ударился о врага");
        }
    }
}
