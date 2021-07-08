using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBonus : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GridManager.instance.SetObjectInCell(null, GridManager.instance.GetIndexCell(transform.position));
        Destroy(gameObject);
    }
}
