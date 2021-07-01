using UnityEngine;


public class BombExplossion : MonoBehaviour
{
    [Header("’арактеристики бомбы")]
    [SerializeField] [Range(1, 3)] private int fireLength = 3; //радиус взрыва   
    [SerializeField] private float time = 3;
    ////[Space(5)]
    ////[Header("Ёффекты при взрыве")]
    ////[SerializeField] private GameObject effect; // эффект взрыва

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

