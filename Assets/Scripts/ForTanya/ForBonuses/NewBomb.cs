using UnityEngine;

public class NewBomb : MonoBehaviour
{
    [SerializeField] private GameObject bomb;

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
           //��� �� ���������� � ���� ������ ����� �����
        }

        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
        Destroy(gameObject);
    }
}
