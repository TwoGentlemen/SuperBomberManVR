using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class BehaviourExplosion : MonoBehaviour
    {

        // Скопировала скрипт на переделку на будущее, вдруг пригодится

        public void SetBehavioutObject(GameObject obj)
        {
            if(obj == null) { return;}

            switch (obj.tag)
            {
                case "DestructableObject":
                    DestructibleObject(obj);
                    break;
                case "Player":Debug.Log("Игрок попал в зону поражения!"); break;
                default:
                    break;
            }
        }

        private void DestructibleObject(GameObject obj)
        {
            var index = GridManager.instance.GetIndexCell(obj.transform.position);
            GridManager.instance.SetObjectInCell(null,index);
            Destroy(obj);
        }
    } 

