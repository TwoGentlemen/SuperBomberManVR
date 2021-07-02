using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    //����� ����������� ����� ���������� ������ ������ ������
    //������ ������ ����� ������ ��� ���?

    private Vector3 Resp;

    //���������� ������
    [SerializeField] [Range(1, 100)] private int healthPoints = 3;


    public void Start()
    {
        Resp = transform.position;
    }

    public void DamagePlayer()
    {

        healthPoints -= 1;

        // ��� ������ ���� ������

        if (healthPoints <= 0)
        {
            Dead();
            return;
        }

        transform.position = Resp;
    }


    private void Dead()
    {
        //������� ��������� ����
    }
}
