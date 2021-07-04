using UnityEngine;

public class AddBomb : MonoBehaviour
{
    public readonly float _probability = 15;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SpawnBomb>().TimerStop();
        }

        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
        Destroy(gameObject);
    }

}
