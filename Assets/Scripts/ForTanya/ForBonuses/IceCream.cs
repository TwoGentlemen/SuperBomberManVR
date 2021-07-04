using UnityEngine;

public class IceCream : MonoBehaviour
{
    public readonly float _probability = 25;

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
            //сделать добавление очков, когда будет система очков
        }

    }

}
