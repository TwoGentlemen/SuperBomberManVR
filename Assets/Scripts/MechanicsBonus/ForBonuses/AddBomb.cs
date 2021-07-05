using UnityEngine;

public class AddBomb : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.spawnBomb.AddBombQuantityInRow();

            GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
            Destroy(gameObject);
        }


    }

}
