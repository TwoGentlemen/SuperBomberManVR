using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private int fireLength = 1;
    
    // �������� ��������

    private void Explosion()
    {
        GridManager.instance.Explosion(transform.position);
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(gameObject.transform.position));
        Destroy(gameObject);
    }
}
