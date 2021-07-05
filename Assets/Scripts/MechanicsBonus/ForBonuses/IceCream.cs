using UnityEngine;

public class IceCream : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //������� ���������� �����, ����� ����� ������� �����

            GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
            Destroy(gameObject);
        }


    }
}
