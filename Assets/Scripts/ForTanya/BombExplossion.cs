using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplossion : MonoBehaviour
{


    //—крипт дл€ переделывани€


    [Header("’арактеристики бомбы")]
    [SerializeField] [Range(1, 3)] private int fireLength = 1; //радиус взрыва   

    //[Space(5)]
    //[Header("Ёффекты при взрыве")]
    //[SerializeField] private GameObject effect; // эффект взрыва

    private BehaviourExplosion explosion = new BehaviourExplosion();

    public void ExplosionActivate(float time = 2)
    {
        //вызов функции взрыва с задержкой
        Invoke("Explosion", time);
    }

    private void Explosion()
    {

        foreach (var collider in Physics.OverlapSphere(transform.position, fireLength))
        {

            switch (collider.tag)
            {
                //case "Destructible": explosion.DestructibleObject(collider, force, explosionRadius); break;
                //case "Bomb": explosion.BombActivateBomb(collider.gameObject); break;
                //case "Monster": explosion.DestructibleObject(collider, force, explosionRadius); break;
                //case "Player": collider.GetComponent<ReactionOnAttack>().DamagePlayer(1); break;
                //default: break;
            }

        }
        Destroy(gameObject);

        //if (effect != null)
        //{
        //    var ef = Instantiate(effect, transform.position, transform.rotation);
        //    Destroy(ef, ef.GetComponent<ParticleSystem>().main.duration);
        //}

    }
}
