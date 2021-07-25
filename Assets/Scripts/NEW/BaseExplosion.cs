using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NEW;
using System;

[RequireComponent(typeof (AudioSource))]
public class BaseExplosion : MonoBehaviour
{
    [SerializeField] GameObject explosionParticle;
    [SerializeField] GameObject bomb;

    [SerializeField] private AudioSource audioSource;
    private int radius = 1;
    private float timerStartExplosion = 4f;

    private Vector2Int indexCell;
   
    private void Start()
    {
        if(GridManager.instance == null || Player.instanstance == null) { Debug.LogError("Not GridManager");}
       // audioSource = GetComponent<AudioSource>();

        radius = Player.instanstance.GetRadiusExplosion();
        indexCell = GridManager.instance.GetIndexCell(transform.position);
        ActivationBomb();
    }

    protected virtual void ActivationBomb()
    {
        Invoke("Explosion", timerStartExplosion);
    }

    protected virtual void Explosion()
    {
        var effectExplosion = Instantiate(explosionParticle,transform.position,Quaternion.identity);
        Destroy(effectExplosion,5f);

        audioSource.clip = GameManager.instance.audioData.explosion;
        audioSource.Play();

        var objectsInRadius = GridManager.instance.Explosion(transform.position,radius);

        foreach (var item in objectsInRadius)
        {
            switch (item.tag)
            {
                case "Player": Player.instanstance.Damage(); break;
                case "Enemy": item.GetComponent<EnemyBaseAI>().Damage(); break;
                case "DestructableObject": item.GetComponent<DestructableWall>().DestroyWall(); break;
                case "Bonus": Destroy(item); break;
                default: break;
            }
        }
        GridManager.instance.SetObjectInCell(null, indexCell);

        bomb.SetActive(false);
        Destroy(gameObject,5f);
    }

}
