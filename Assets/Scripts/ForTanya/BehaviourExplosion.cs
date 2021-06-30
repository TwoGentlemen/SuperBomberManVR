using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourExplosion : MonoBehaviour
{

    // ����������� ������ �� ��������� �� �������, ����� ����������

    public void BombActivateBomb(GameObject bomb)
    {
        if (bomb == null) { return; }

        //var explos = bomb.GetComponent<BombExplosion>();
        //explos.ExplosionActivate(0.5f);
    }

    public void DestructibleObject(Collider collider, float force, float explosionRadius)
    {
        if (collider == null) { return; }

        if (collider.attachedRigidbody) //���� ������ ����� ������
        {
            collider.attachedRigidbody.AddExplosionForce(force, transform.position, explosionRadius);
        }

        Destroy(collider.gameObject, 1);
    }
}
