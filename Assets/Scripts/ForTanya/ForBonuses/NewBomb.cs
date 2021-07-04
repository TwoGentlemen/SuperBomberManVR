using UnityEngine;

public class NewBomb : MonoBehaviour
{
    public readonly float _probability = 25;
    [SerializeField] private GameObject bomb;

    private void OnCollisionEnter(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
           //как то установить в руку игрока новую бомбу
        }

        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
        Destroy(gameObject);
    }
}
