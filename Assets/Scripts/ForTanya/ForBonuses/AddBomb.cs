using UnityEngine;

public class AddBomb : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpawnBomb>().AddBombQuantityInRow();

            GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
            Destroy(gameObject);
        }


    }

}
