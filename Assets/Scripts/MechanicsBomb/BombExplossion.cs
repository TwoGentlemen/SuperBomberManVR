using UnityEngine;


public class BombExplossion : MonoBehaviour
{
    [Header("�������������� �����")]
    [SerializeField] private int fireLength = 1;   
    [SerializeField] private float time = 3;

    ////[Header("������� ��� ������")]
    ////[SerializeField] private GameObject effect; 

    private void Start()
    {
        Invoke("Explosion",time);
    }

    private void Explosion()
    {
        GridManager.instance.Explosion(transform.position,fireLength);
        GridManager.instance.SetObjectInCell(null,GridManager.instance.GetIndexCell(gameObject.transform.position));
        Destroy(gameObject);
    }
}  

