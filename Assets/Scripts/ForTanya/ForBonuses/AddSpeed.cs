using UnityEngine;

public class AddBomb : MonoBehaviour
{
    public readonly float _probability = 30;
    private float _newSpeed = 200;

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
            ob.GetComponent<ControllPlayerPC>().SetSpeed(_newSpeed);
        }
    }

}
