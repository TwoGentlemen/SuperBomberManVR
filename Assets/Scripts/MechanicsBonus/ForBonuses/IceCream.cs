using UnityEngine;

public class IceCream : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //сделать добавление очков, когда будет система очков

            GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
            Destroy(gameObject);
        }


    }
}
