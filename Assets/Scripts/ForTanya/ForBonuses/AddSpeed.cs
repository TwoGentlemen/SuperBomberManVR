using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    public readonly float _probability = 15;
    [SerializeField]private float newspeed = 50;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ControllPlayerPC>().AddSpeed(newspeed);
        }

        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
        Destroy(gameObject);
    }


}
