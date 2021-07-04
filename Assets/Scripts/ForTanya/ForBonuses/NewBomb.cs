using UnityEngine;

public class NewBomb : MonoBehaviour
{
    public readonly float _probability = 10;
    [SerializeField] private GameObject bomb;

    void Start()
    {
        //сделать анимацию движения
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        GameObject ob = collision.gameObject;
        if (ob.CompareTag("Player"))
        {
           //как то установить в руку игрока новую бомбу
        }
    }
}
