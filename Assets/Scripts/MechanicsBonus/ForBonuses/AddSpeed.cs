using UnityEngine;

public class AddSpeed : MonoBehaviour
{
    [SerializeField]private float newspeed = 50;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerControllVR>().AddSpeed();

            GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
            Destroy(gameObject);
        }
    }
}
