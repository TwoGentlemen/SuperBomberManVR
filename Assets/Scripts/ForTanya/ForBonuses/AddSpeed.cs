using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    public readonly float _probability = 30;
    [SerializeField]private float newspeed = 200;

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
            ob.GetComponent<ControllPlayerPC>().SetSpeed(newspeed);
        }
    }


}
