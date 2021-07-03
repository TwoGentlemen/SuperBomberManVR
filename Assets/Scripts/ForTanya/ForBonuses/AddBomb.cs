using UnityEngine;

public class AddSpped : MonoBehaviour
{
    public readonly float _probability = 15;

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
            ob.GetComponent<SpawnBomb>().SetTimer(0);
        }
    }

}
