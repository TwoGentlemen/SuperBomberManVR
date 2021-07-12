using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    //����� ����������� ����� ���������� ������ ������ ������
    //������ ������ ����� ������ ��� ���?

    private Vector3 Resp;

    //���������� ������
    [SerializeField] [Range(1, 15)] private int healthPoints = 3;
    [SerializeField] GameObject[] imageHP;

    [SerializeField] float timeOneLive = 60; //����� ����� ����� 
    [SerializeField] Image imageLiveTimer;


    public void Start()
    {
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
        

        // ��� ������ ���� ������

        if (healthPoints <= 0)
        {
            imageHP[0].SetActive(false);
            Dead();
            return;
        }
        imageHP[healthPoints].SetActive(false);
        transform.position = Resp;

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
            Debug.Log("����� �������� � �����");
        }
    }
}
