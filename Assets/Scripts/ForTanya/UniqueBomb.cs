using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] [Range(1, 3)] private int fireLength = 3;
    
    // Добавить анимацию

    private void Explosion()
    {
        GridManager.instance.Explosion(transform.position, fireLength);
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(gameObject.transform.position));
        Destroy(gameObject);
    }
}
