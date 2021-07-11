using UnityEngine;


public class BombExplossion : MonoBehaviour
{
    [Header("�������������� �����")]
    [SerializeField] private int fireLength = 1;   
    [SerializeField] private float time = 3;

    [Header("������� ��� ������")]
    [SerializeField] private GameObject effect; 

    private void Start()
    {
        ActivateExplosion();
    }

    protected virtual void ActivateExplosion()
    {
        Invoke("Explosion", time);
    }

    protected virtual void Explosion()
    {
        GridManager.instance.Explosion(transform.position,fireLength);
        GridManager.instance.SetObjectInCell(null,GridManager.instance.GetIndexCell(gameObject.transform.position));

        var ex = Instantiate(effect, transform.position,Quaternion.identity);
        Destroy(ex,1f);
        Destroy(gameObject);
    }
}  

