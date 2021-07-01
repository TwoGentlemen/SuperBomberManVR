using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBom : MonoBehaviour
{
    //[Header("’арактеристики бомбы")]
    //[SerializeField] [Range(1, 3)] private int fireLength = 3; //радиус взрыва   

    ////[Space(5)]
    ////[Header("Ёффекты при взрыве")]
    ////[SerializeField] private GameObject effect; // эффект взрыва

    //[SerializeField] private int step = 2;
    //private Vector3 gridStart = new Vector3(1, 1, 17);
    //private Vector3 gridWith = new Vector3(25, 1, 17);
    //private Vector3 gridHight = new Vector3(1, 1, -3);

    //private BehaviourExplosion explosion = new BehaviourExplosion();
    //private Grid grid;
    //private int time = 2;
    //private int cellQuantity = 1;


    //void Start()
    //{
    //    grid = new Grid(gridStart, gridWith, gridHight, step);
    //    Invoke("Explosion", time);
    //}


    //private void Explosion()
    //{
    //    var bombPosition = grid.GetIndexCell(transform.position);

    //    for (int i = 1; i <= cellQuantity; i++)
    //    {
    //        if (!grid.isEmpty(bombPosition.x + i, bombPosition.y))
    //        {
    //            GameObject ob = grid.GetGameObject(bombPosition.x + i, bombPosition.y);

    //            if (ob.tag == "Wall") break;
    //            else if (ob.tag != "Bomb")
    //            {
    //                grid.ActiveOrNotCell(ob.transform.position, true, null);
    //                Destroy(ob);

    //            }

    //        }
    //    }

    //    for (int i = 1; i <= cellQuantity; i++)
    //    {
    //        if (!grid.isEmpty(bombPosition.x, bombPosition.y + i))
    //        {
    //            GameObject ob = grid.GetGameObject(bombPosition.x, bombPosition.y + i);

    //            if (ob.tag == "Wall") break;
    //            else if (ob.tag != "Bomb")
    //            {
    //                grid.ActiveOrNotCell(ob.transform.position, true, null);
    //                Destroy(ob);

    //            }

    //        }
    //    }

    //    for (int i = -1; i >= -cellQuantity; i--)
    //    {
    //        if (!grid.isEmpty(bombPosition.x + i, bombPosition.y))
    //        {
    //            GameObject ob = grid.GetGameObject(bombPosition.x + i, bombPosition.y);

    //            if (ob.tag == "Wall") break;
    //            else if (ob.tag != "Bomb")
    //            {
    //                grid.ActiveOrNotCell(ob.transform.position, true, null);
    //                Destroy(ob);

    //            }

    //        }
    //    }

    //    for (int i = -1; i >= -cellQuantity; i--)
    //    {
    //        if (!grid.isEmpty(bombPosition.x, bombPosition.y + i))
    //        {
    //            GameObject ob = grid.GetGameObject(bombPosition.x, bombPosition.y + i);

    //            if (ob.tag == "Wall") break;
    //            else if (ob.tag != "Bomb")
    //            {
    //                grid.ActiveOrNotCell(ob.transform.position, true, null);
    //                Destroy(ob);

    //            }

    //        }
    //    }

    //    Destroy(gameObject);

    //    //if (effect != null)
    //    //{
    //    //    var ef = Instantiate(effect, transform.position, transform.rotation);
    //    //    Destroy(ef, ef.GetComponent<ParticleSystem>().main.duration);
    //    //}
    //}
}
