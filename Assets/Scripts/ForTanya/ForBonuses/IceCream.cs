using UnityEngine;

public class IceCream : MonoBehaviour
{
    public readonly float _probability = 25;

    void Start()
    {
        //������� �������� �������� 
    }


    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        GameObject ob = collision.gameObject;
        if (ob.CompareTag("Player"))
        {
            //������� ���������� �����, ����� ����� ������� �����
        }

    }

}
