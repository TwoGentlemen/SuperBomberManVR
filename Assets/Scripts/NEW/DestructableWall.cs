using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NEW { 
    public class DestructableWall : MonoBehaviour
    {
        [SerializeField] private GameObject objectInWall;
        
        private Vector2Int indexCell;
        private void Start()
        {
            indexCell = GridManager.instance.GetIndexCell(transform.position);

            if(objectInWall != null)
                objectInWall.SetActive(false);
        }


        public void SetObjectInWall(GameObject obj)
        {
            if(objectInWall != null) { return;}
            objectInWall = Instantiate(obj,GridManager.instance.GetPosCell(indexCell),Quaternion.identity);
            objectInWall.SetActive(false);
        }

        public void DestroyWall()
        {

            if (objectInWall == null)
            {
                GridManager.instance.SetObjectInCell(null, indexCell);
            }
            else
            {
                objectInWall.SetActive(true);
                GridManager.instance.SetObjectInCell(objectInWall, indexCell);
            }

            Destroy(gameObject);
        }
    }
}
